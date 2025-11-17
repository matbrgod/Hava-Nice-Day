using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternaHava : MonoBehaviour
{
    public bool lanternaFalhando;
    private bool aumentando = false;
    public Light2D light2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject lanterna;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lanterna.SetActive(!lanterna.activeSelf);
        }
        if (lanternaFalhando == true)
        {
            LanternaFalhando();
        }
    }

    public void LanternaFalhando()
    {
        if (aumentando == true)
        {
            if (light2D != null)
            {
                light2D.pointLightOuterRadius -= 0.1f * Time.deltaTime;
                if (light2D.pointLightOuterRadius <= 5f)
                {
                    aumentando = false;
                }
            }
        }
        if (aumentando == false)
        {
            if(light2D != null)
            {
                light2D.pointLightOuterRadius += 0.5f * Time.deltaTime;
                if (light2D.pointLightOuterRadius >= 11.3f)
                {
                    aumentando = true;
                }
            }
        }
    }
}
