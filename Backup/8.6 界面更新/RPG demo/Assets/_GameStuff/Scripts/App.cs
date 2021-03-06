using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds 
{ 
public class App : MonoBehaviour
{
    public GmdsManifest m_Manifest;

    private static App m_Instance;
    void Awake()
    {
        m_Instance = this;
    }
    public static App Instance
    {
        get { return m_Instance; }
    #if UNITY_EDITOR
        // Bleh. Needed by BuildTiltBrush.cs
        set { m_Instance = value; }
    #endif
    }
        private void Start()
        {

        }
    }
}