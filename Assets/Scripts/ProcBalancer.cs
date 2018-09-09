using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility class used to balance out procs so the final result is always the closest possible
/// to the desired chance.
/// </summary>
public class ProcBalancer {
    private float desiredRate;
    private float currentChance;
    private float balanceRatio = 0.1f;
    private readonly int decimalPlaces = 5;

    /// <summary>
    /// Constructor for the ProcBalancer with default balance ratio (0.1)
    /// </summary>
    /// <param name="desiredRate">The desired occurrence rate for the proc</param>
    public ProcBalancer(float desiredRate) {
        this.desiredRate = desiredRate;
        currentChance = desiredRate;
    }

    /// <summary>
    /// Constructor for the ProcBalancer
    /// </summary>
    /// <param name="desiredRate">The desired occurrence rate for the proc</param>
    /// <param name="balanceRatio">How much will the balancer affect the chance:
    /// lower values are more subtle while higher ones are more noticeable. Default = 0.1</param>
    public ProcBalancer(float desiredRate, float balanceRatio) {
        this.desiredRate = desiredRate;
        this.balanceRatio = balanceRatio;
        currentChance = desiredRate;
    }

    /// <summary>
    /// Rolls the proc according to the current chance
    /// </summary>
    /// <returns>Whether the proc was successful or not</returns>
    public bool Proc() {
        float rounding = Mathf.Pow(10f, decimalPlaces);
        if (Random.value > currentChance) {
            currentChance += balanceRatio * desiredRate;
            currentChance = Mathf.Round(currentChance * rounding) / rounding;
            return false;
        } else {
            currentChance -= balanceRatio * (1f - desiredRate);
            currentChance = Mathf.Round(currentChance * rounding) / rounding;
            return true;
        }
    }

    public float GetCurrentChance() {
        return currentChance;
    }
}