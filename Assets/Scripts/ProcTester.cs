using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcTester : MonoBehaviour {

    //Scene Objects
    public RectTransform line;
    public RectTransform column;
    public RectTransform background;
    public InputField chanceInput;
    public InputField triesInput;
    public InputField balanceRatioInput;
    public LogWindow logWindow;

    private float desiredChance;
    private float balanceRatio;
    private int tries;
    private ProcBalancer balancer;
    private Dictionary<float, int> procCount = new Dictionary<float, int>();
    private bool[] resultsBalancer;
    private bool[] resultsNormal;
    private List<RectTransform> columns = new List<RectTransform>();
    private float highestChance;
    private float lowestChance;

    private float h;
    private float w;

    private void Start() {
        h = background.rect.height;
        w = background.rect.width;
    }

    public void Balance() {
        Init();
        float sumBalancer = 0f;
        int balancedProcs = 0;
        int normalProcs = 0;
        for (int i = 0; i < tries; i++) {
            if (procCount.ContainsKey(balancer.GetCurrentChance()))
                procCount[balancer.GetCurrentChance()]++;
            else
                procCount.Add(balancer.GetCurrentChance(), 1);
            highestChance = Mathf.Max(highestChance, balancer.GetCurrentChance());
            lowestChance = Mathf.Min(lowestChance, balancer.GetCurrentChance());
            sumBalancer += balancer.GetCurrentChance();
            resultsBalancer[i] = balancer.Proc();
            resultsNormal[i] = desiredChance >= Random.value;
            RectTransform newColumn = Instantiate(column);
            columns.Add(newColumn);
            newColumn.transform.SetParent(background);
            newColumn.transform.SetAsFirstSibling();
            newColumn.anchoredPosition = new Vector2((w / tries) * i, 0);
            newColumn.sizeDelta = new Vector2(w / tries, balancer.GetCurrentChance() * h);
            if (resultsBalancer[i])
                balancedProcs++;
            if (resultsNormal[i])
                normalProcs++;
        }

        LogProcs(balancedProcs, normalProcs);
    }

    private void Init() {
        desiredChance = float.Parse(chanceInput.text);
        balanceRatio = float.Parse(balanceRatioInput.text);
        tries = int.Parse(triesInput.text);
        line.localPosition = new Vector2(0, (desiredChance * h) - h / 2);
        line.gameObject.SetActive(true);
        highestChance = lowestChance = desiredChance;
        balancer = new ProcBalancer(desiredChance, balanceRatio);
        resultsBalancer = new bool[tries];
        resultsNormal = new bool[tries];
        foreach (RectTransform item in columns) {
            Destroy(item.gameObject);
        }
        columns.Clear();
        procCount.Clear();
    }

    private void LogProcs(int balancedProcs, int normalProcs) {
        string log = "";
        log += "Tested " + desiredChance * 100 + "% chance in " + tries + " tries.\n";
        log += "Balanced results hits: " + balancedProcs + " - " + 1f * balancedProcs / tries * 100 + "%\n";
        log += "Normal results hits: " + normalProcs + " - " + 1f * normalProcs / tries * 100 + "%\n";
        log += "Highest chance: " + highestChance * 100 + "%\n";
        log += "Lowest Chance: " + lowestChance * 100 + "%\n";
        log += "Chance occurence: \n ";
        foreach (var item in procCount) {
            log += item.Key * 100 + "% - " + item.Value + " times\n";
        }
        Debug.Log(log);
        logWindow.UpdateText(log);
    }
}