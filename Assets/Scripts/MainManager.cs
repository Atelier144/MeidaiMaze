using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainManager : GameManager
{
    const int FIRE = 0;
    const int THUNDER = 1;
    const int ICE = 2;

    [SerializeField] GameObject gameObjectImageBackground;

    [SerializeField] GameObject gameObjectPanelHP;
    [SerializeField] GameObject gameObjectPanelGold;
    [SerializeField] GameObject gameObjectPanelAhead;
    [SerializeField] GameObject gameObjectPanelMeidai;
    [SerializeField] GameObject gameObjectPanelMonster;
    [SerializeField] GameObject gameObjectPanelAnswers;

    [SerializeField] GameObject gameObjectImageEffect;

    [SerializeField] GameObject gameObjectImageMonster;
    [SerializeField] GameObject gameObjectTextMonsterName;
    [SerializeField] GameObject gameObjectTextWeakpoint;
    [SerializeField] GameObject gameObjectImageWeakpoint;
    [SerializeField] GameObject gameObjectTextAttackPoint;
    [SerializeField] GameObject gameObjectTextAttackPointValue;
    [SerializeField] GameObject gameObjectSliderAttackTime;
    [SerializeField] GameObject gameObjectImageAttackTimeIcon;

    [SerializeField] GameObject gameObjectSliderHP;
    [SerializeField] GameObject gameObjectTextHP;

    [SerializeField] Button[] buttonsAnswers = new Button[3];
    [SerializeField] Text[] textsButtonsAnswers = new Text[3];

    Animator animatorImageEffect;

    Slider sliderAttackTime;

    Slider sliderHP;
    Text textHP;

    int step = 1;
    int hp = 100;
    int maxHp = 100;

    int minAttackTime = 150;
    int maxAttackTime = 300;
    int minAttackPoint = 0;
    int maxAttackPoint = 100;

    int currentAttackTime;
    int currentAttackPoint = 12;

    int currentAttackTimeMax;

    bool doesMonsterExist = false;



    // Start is called before the first frame update
    protected override void Start()
    {
        animatorImageEffect = gameObjectImageEffect.GetComponent<Animator>();

        sliderHP = gameObjectSliderHP.GetComponent<Slider>();
        textHP = gameObjectTextHP.GetComponent<Text>();

        sliderAttackTime = gameObjectSliderAttackTime.GetComponent<Slider>();

        StartCoroutine(CoroutineIntroduction());

        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (doesMonsterExist)
        {
            sliderAttackTime.value = currentAttackTime;
        }
    }

    private void FixedUpdate()
    {
        if (doesMonsterExist)
        {
            if(currentAttackTime > 0)
            {
                currentAttackTime--;
            }
            else
            {
                StartCoroutine(MonsterAttack());
            }
        }
    }

    IEnumerator CoroutineIntroduction()
    {
        gameObjectImageBackground.GetComponent<Image>().DOColor(new Color(1.0f, 1.0f, 1.0f), 3.0f);
        yield return new WaitForSeconds(4.0f);

        gameObjectPanelHP.SetActive(true);
        gameObjectPanelGold.SetActive(true);
        gameObjectPanelAhead.SetActive(true);
    }

    public void OnClickButtonAhead()
    {
        StartCoroutine(CoroutineOnClickButtonAhead());
    }

    public void OnClickButtonEscape()
    {
        StartCoroutine(CoroutineOnClickButtonEscape());
    }

    IEnumerator CoroutineOnClickButtonAhead()
    {
        gameObjectImageBackground.GetComponent<RectTransform>().DOScale(new Vector3(5.0f, 5.0f, 5.0f), 2.0f);
        gameObjectImageBackground.GetComponent<Image>().DOColor(new Color(1.0f, 1.0f, 1.0f, 0.0f), 2.0f);
        gameObjectPanelAhead.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        gameObjectImageBackground.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gameObjectImageBackground.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        AddStep();
    }

    IEnumerator CoroutineOnClickButtonEscape()
    {
        gameObjectPanelAhead.SetActive(false);
        animatorImageEffect.SetTrigger("Escape");
        yield return new WaitForSeconds(2.0f);
    }

    void AddStep()
    {
        step++;
        switch (Random.Range(0,2))
        {
            case 0:
                gameObjectPanelAhead.SetActive(true);
                break;
            case 1:
                StartCoroutine(AppearMonster());
                break;
        }
    }

    IEnumerator AppearMonster()
    {
        gameObjectPanelMonster.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        doesMonsterExist = true;

        ActivateMonsterStatus(true);
        ActivateMeidaiAndAnswers(true);

        sliderAttackTime.maxValue = 500;
        currentAttackTime = 500;
    }

    public void OnClickButtonAnswer(int s)
    {
        if (doesMonsterExist)
        {
            StartCoroutine(Attack(s));
            doesMonsterExist = false;
        }
    }

    IEnumerator MonsterAttack()
    {
        ActivateMonsterStatus(false);
        ActivateMeidaiAndAnswers(false);
        doesMonsterExist = false;

        hp -= currentAttackPoint;
        if (hp > 0)
        {
            animatorImageEffect.SetTrigger("Damaged");
            currentAttackTime = 20;
            sliderHP.value = hp;
            textHP.text = hp + " / " + maxHp;
            yield return new WaitForSeconds(2.0f);

            ActivateMonsterStatus(true);
            ActivateMeidaiAndAnswers(true);
            doesMonsterExist = true;
        }
        else
        {
            animatorImageEffect.SetTrigger("Defeated");
            hp = 0;
            sliderHP.value = hp;
            textHP.text = hp + " / " + maxHp;
            yield return new WaitForSeconds(6.0f);
            MoveToEndSceneFromMainScene();
        }
    }

    IEnumerator Attack(int element)
    {
        string[] triggerNames = { "FireAttack", "ThunderAttack", "IceAttack" };
        animatorImageEffect.SetTrigger(triggerNames[element]);
        yield return new WaitForSeconds(5.0f);
    }

    void ActivateMonsterStatus(bool s)
    {
        gameObjectImageAttackTimeIcon.SetActive(s);
        gameObjectImageWeakpoint.SetActive(s);
        gameObjectSliderAttackTime.SetActive(s);
        gameObjectTextWeakpoint.SetActive(s);
        gameObjectTextAttackPoint.SetActive(s);
        gameObjectTextAttackPointValue.SetActive(s);
    }

    void ActivateMeidaiAndAnswers(bool s)
    {
        gameObjectPanelMeidai.SetActive(s);
        gameObjectPanelAnswers.SetActive(s);
    }
}
