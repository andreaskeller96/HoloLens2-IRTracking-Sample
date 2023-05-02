
using UnityEngine;
using System;
using IRToolTrack;
using System.Linq;


#if ENABLE_WINMD_SUPPORT
using System.Threading.Tasks;
using HL2IRToolTracking;
#endif

public class IRToolTracking : MonoBehaviour
{
#if ENABLE_WINMD_SUPPORT
    HL2ResearchMode researchMode;
#endif
    private bool sensorStarted = false;
    private bool startToolTracking = false;

    private IRToolController[] tools = null;

    public float[] GetToolTransform(string identifier)
    {
        var toolTransform = Enumerable.Repeat<float>(0, 8).ToArray();
#if ENABLE_WINMD_SUPPORT
        toolTransform = researchMode.GetToolTransform(identifier);        
#endif
        return toolTransform;

    }

    public Int64 GetTimestamp()
    {
#if ENABLE_WINMD_SUPPORT
        return researchMode.GetTrackingTimestamp();
#endif
        return 0;
    }

    public void Start()
    {
        //Find Tool Controllers and add them to the tracking
        tools = FindObjectsOfType<IRToolController>();
        StartToolTracking();
    }

    public void StartToolTracking()
    {
        Debug.Log("Start Tracking");
        if (!sensorStarted) StartSensors();
#if ENABLE_WINMD_SUPPORT
        if (!startToolTracking && sensorStarted){
            researchMode.RemoveAllToolDefinitions();
            researchMode.SetupTracking();
            foreach (IRToolController tool in tools)
            {
                researchMode.AddToolDefinition(tool.sphere_count, tool.sphere_positions, tool.sphere_radius, tool.identifier);
                tool.StartTracking();
            }
            researchMode.StartToolTracking();
            startToolTracking = true;
        }
#endif
    }

    public void StopToolTracking()
    {

#if ENABLE_WINMD_SUPPORT
        if (sensorStarted && startToolTracking){
            researchMode.StopToolTracking();
            startToolTracking = false;
            foreach (IRToolController tool in tools)
            {
                tool.StopTracking();
            }
        }
#endif
        Debug.Log("Stopped Tracking");
    }

    private void StartSensors()
    {
        print("Starting Sensors");
#if ENABLE_WINMD_SUPPORT
        // Get Unity Origin Coordinate
#if UNITY_2021_2_OR_NEWER
        //var unityWorldOrigin = Microsoft.Windows.Perception.Spatial.SpatialCoordinateSystem
        Windows.Perception.Spatial.SpatialCoordinateSystem unityWorldOrigin = Microsoft.MixedReality.OpenXR.PerceptionInterop.GetSceneCoordinateSystem(UnityEngine.Pose.identity) as Windows.Perception.Spatial.SpatialCoordinateSystem;
#elif UNITY_2020_1_OR_NEWER
        IntPtr WorldOriginPtr = UnityEngine.XR.WindowsMR.WindowsMREnvironment.OriginSpatialCoordinateSystem;
        var unityWorldOrigin = Marshal.GetObjectForIUnknown(WorldOriginPtr) as Windows.Perception.Spatial.SpatialCoordinateSystem;
#else
        IntPtr WorldOriginPtr = UnityEngine.XR.WSA.WorldManager.GetNativeISpatialCoordinateSystemPtr();
        var unityWorldOrigin = Marshal.GetObjectForIUnknown(WorldOriginPtr) as Windows.Perception.Spatial.SpatialCoordinateSystem;
#endif

        print(unityWorldOrigin);

        if (researchMode == null)
        {
            researchMode = new HL2ResearchMode();
        }
        // Set Unity Origin Coordinate
        researchMode.SetReferenceCoordinateSystem(unityWorldOrigin);
        // Start Ahat camera
        researchMode.InitializeDepthSensor();

        // false: do not reconstruct point cloud; true: start IR sphere filtering
        researchMode.StartDepthSensorLoop(false, true); 

        sensorStarted = true;
#endif


    }

    public async void StopSensorsEvent()
    {
        startToolTracking = false;

#if ENABLE_WINMD_SUPPORT
        await researchMode.StopAllSensorDevice();
        researchMode = null;
        sensorStarted = false;
#endif
    }

    public void ExitApplication()
    {
        StopSensorsEvent();
        Application.Quit();
    }
}