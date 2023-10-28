using UnityEngine;
using UnityEngine.UI;

public class HoverUi : MonoBehaviour
{
    static string moneyPstr = "���� ������ �߻��մϴ�.";
    static string moneyNstr = "���� ������ �߻��մϴ�.";
    static string stressPstr = "��ŭ ��Ʈ������ ����ϴ�.";
    static string stressNstr = "��ŭ ��Ʈ������ �޽��ϴ�.";
    static string lovePstr = "�� ȣ������ ����ϴ�.";
    static string loveNstr = "�� ȣ������ �ҽ��ϴ�.";
    static string bloodPstr = "L�� �Ǹ� �����մϴ�.";
    static string bloodNstr = "L�� �Ǹ� �ҽ��ϴ�.";

    [Header("���� ����")]
    [SerializeField] GameObject moneyP;
    [SerializeField] GameObject stressP;
    [SerializeField] GameObject loveP;
    [SerializeField] GameObject bloodP;

    [Header("������ ����")]
    [SerializeField] GameObject moneyN;
    [SerializeField] GameObject stressN;
    [SerializeField] GameObject loveN;
    [SerializeField] GameObject bloodN;

    [Header("���� UI")]
    [SerializeField] HoverChangeUi moneyChange;
    [SerializeField] HoverChangeUi stressChange;
    [SerializeField] HoverChangeUi loveChange;
    [SerializeField] HoverChangeUi bloodChange;

    public void Init(int momeyChangeAmount, int stressChangeAmount, int loveChangeAmount, float bloodChangeAmount)
    {
        // �����
        {
            //string str = "";
            //str += name + " init";
            //str += " || momeyChangeAmount : " + momeyChangeAmount;
            //str += " || stressChangeAmount : " + stressChangeAmount;
            //str += " || loveChangeAmount : " + loveChangeAmount;
            //str += " || bloodChangeAmount : " + bloodChangeAmount;
            //Debug.Log(str);
        }       

        float CurrentMoney = ScheduleResources.Instance.PreviewMoney;
        float CurrentStress = ScheduleResources.Instance.PreviewStress;
        float CurrentLove = ScheduleResources.Instance.PreviewLove;
        float CurrentBlood = ScheduleResources.Instance.PreviewBlood;

        // ���� ���� ��� (��ȭ�� ���� ��� ����)
        {
            bool isMoneyChange = !(momeyChangeAmount == 0); // �� ��ȭ�� �ִ°�?                                                            
            if (isMoneyChange)
            {
                bool changePositive = (momeyChangeAmount > 0);
                float changeAmount = Mathf.Abs(momeyChangeAmount);
                if (changePositive)
                {
                    moneyP.SetActive(true);
                    moneyN.SetActive(false);
                    moneyP.GetComponent<Text>().text = changeAmount + moneyPstr;
                }
                else
                {
                    moneyP.SetActive(false);
                    moneyN.SetActive(true);
                    moneyN.GetComponent<Text>().text = changeAmount + moneyNstr;
                }
                moneyChange.gameObject.SetActive(true);
                moneyChange.Init(changePositive, CurrentMoney, CurrentMoney + momeyChangeAmount); // ��ȭ�� ���� �ʱ�ȭ
            }
            else
            {
                moneyP.SetActive(false);
                moneyN.SetActive(false);
                moneyChange.gameObject.SetActive(false);
            }

            bool isStressChange = !(stressChangeAmount == 0);
            if (isStressChange)
            {
                bool changePositive = (stressChangeAmount < 0);
                float changeAmount = Mathf.Abs(stressChangeAmount);
                if (changePositive)
                {
                    stressP.SetActive(true);
                    stressN.SetActive(false);
                    stressP.GetComponent<Text>().text = changeAmount + stressPstr;
                }
                else
                {
                    stressP.SetActive(false);
                    stressN.SetActive(true);
                    stressN.GetComponent<Text>().text = changeAmount + stressNstr;
                }
                stressChange.gameObject.SetActive(true);
                stressChange.Init(changePositive, CurrentStress, CurrentStress + stressChangeAmount);
            }
            else
            {
                stressP.SetActive(false);
                stressN.SetActive(false);
                stressChange.gameObject.SetActive(false);
            }

            bool isLoveChange = !(loveChangeAmount == 0);
            if (isLoveChange)
            {
                bool changePositive = (loveChangeAmount > 0);
                float changeAmount = Mathf.Abs(loveChangeAmount);
                if (changePositive)
                {
                    loveP.SetActive(true);
                    loveN.SetActive(false);
                    loveP.GetComponent<Text>().text = changeAmount + lovePstr;
                }
                else
                {
                    loveP.SetActive(false);
                    loveN.SetActive(true);
                    loveN.GetComponent<Text>().text = changeAmount + loveNstr;
                }
                loveChange.gameObject.SetActive(true);
                loveChange.Init(changePositive, CurrentLove, CurrentLove + loveChangeAmount);
            }
            else
            {
                loveP.SetActive(false);
                loveN.SetActive(false);
                loveChange.gameObject.SetActive(false);
            }

            bool isBloodChange = !(bloodChangeAmount == 0);
            if (isBloodChange)
            {
                bool changePositive = (bloodChangeAmount > 0);
                float changeAmount = Mathf.Abs(bloodChangeAmount);
                if (changePositive)
                {
                    bloodP.SetActive(true);
                    bloodN.SetActive(false);
                    bloodP.GetComponent<Text>().text = changeAmount + bloodPstr;
                }
                else
                {
                    bloodP.SetActive(false);
                    bloodN.SetActive(true);
                    bloodN.GetComponent<Text>().text = changeAmount + bloodNstr;
                }
                bloodChange.gameObject.SetActive(true);
                bloodChange.Init(changePositive, CurrentBlood, CurrentBlood + bloodChangeAmount);
            }
            else
            {
                bloodP.SetActive(false);
                bloodN.SetActive(false);
                bloodChange.gameObject.SetActive(false);
            }
                          
        }
    }
}
