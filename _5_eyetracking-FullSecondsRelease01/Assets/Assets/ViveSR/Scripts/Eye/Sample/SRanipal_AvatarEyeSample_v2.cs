//========= Copyright 2018, HTC Corporation. All rights reserved. ===========
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions;
using System.IO;

public class SRanipal_AvatarEyeSample_v2
{
    public TaskTestSession taskTestSession;
}

namespace ViveSR
{


    namespace anipal
    {
        namespace Eye
        {
            public class SRanipal_AvatarEyeSample_v2 : MonoBehaviour
            {
                [SerializeField] private Transform[] EyesModels = new Transform[0];
                [SerializeField] private List<EyeShapeTable> EyeShapeTables;
                /// <summary>
                /// Customize this curve to fit the blend shapes of your avatar.
                /// </summary>
                [SerializeField] private AnimationCurve EyebrowAnimationCurveUpper;
                /// <summary>
                /// Customize this curve to fit the blend shapes of your avatar.
                /// </summary>
                [SerializeField] private AnimationCurve EyebrowAnimationCurveLower;
                /// <summary>
                /// Customize this curve to fit the blend shapes of your avatar.
                /// </summary>
                [SerializeField] private AnimationCurve EyebrowAnimationCurveHorizontal;


                [SerializeField] public float TESTpupilLeft;
                [SerializeField] public float TESTpupilRight;
                [SerializeField] public Vector2 TESTleftEyePositionInSensorArea;
                [SerializeField] public Vector2 TESTrightEyePositionInSensorArea;
                [SerializeField] public Vector3 TESTleftGazeDirectionNormalized;
                [SerializeField] public Vector3 TESTrightGazeDirectionNormalized;
                [SerializeField] public float TESTleftEyeOpenness;
                [SerializeField] public float TESTrightEyeOpenness;
                [SerializeField] public Vector3 TESTleftGazeOrigin;
                [SerializeField] public Vector3 TESTrightGazeOrigin;
                [SerializeField] public float TESTcombinedConvergenceDistanceInmm;
                [SerializeField] public Vector3 TESTkombineradDirektionGaze;
                [SerializeField] public Vector3 TESTkombineradOriginGaze;
                [SerializeField] public bool KlasHasSaved = false;
                /// Klas did this
                
                public bool KeyDownDown;
                public int NoOfTaps = 0;
                //Added by Joseph
                public bool NeededToGetData = true;
                private Dictionary<EyeShape, float> EyeWeightings = new Dictionary<EyeShape, float>();
                private AnimationCurve[] EyebrowAnimationCurves = new AnimationCurve[(int)EyeShape.Max];
                private GameObject[] EyeAnchors;
                private const int NUM_OF_EYES = 2;
                private static EyeData_v2 eyeData = new EyeData_v2();
                private bool eye_callback_registered = false;
                private void Start()
                {

                    if (!SRanipal_Eye_Framework.Instance.EnableEye)
                    {
                        enabled = false;
                        return;
                    }

                    SetEyesModels(EyesModels[0], EyesModels[1]);
                    SetEyeShapeTables(EyeShapeTables);

                    AnimationCurve[] curves = new AnimationCurve[(int)EyeShape.Max];
                    for (int i = 0; i < EyebrowAnimationCurves.Length; ++i)
                    {
                        if (i == (int)EyeShape.Eye_Left_Up || i == (int)EyeShape.Eye_Right_Up) curves[i] = EyebrowAnimationCurveUpper;
                        else if (i == (int)EyeShape.Eye_Left_Down || i == (int)EyeShape.Eye_Right_Down) curves[i] = EyebrowAnimationCurveLower;
                        else curves[i] = EyebrowAnimationCurveHorizontal;
                    }
                    SetEyeShapeAnimationCurves(curves);
                }

                private void Update()
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        KeyDownDown = true;
                        NoOfTaps++;
                        KlasIsSaving();
                    }


                    KlasIsDefining();
                    KlasIsSaving();

                    if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING &&
                        SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT) return;

                    if (NeededToGetData)
                    {
                        if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback == true && eye_callback_registered == false)
                        {
                            SRanipal_Eye_v2.WrapperRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));
                            eye_callback_registered = true;
                        }
                        else if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback == false && eye_callback_registered == true)
                        {
                            SRanipal_Eye_v2.WrapperUnRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));
                            eye_callback_registered = false;
                        }
                        else if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback == false)
                            SRanipal_Eye_API.GetEyeData_v2(ref eyeData);

                        //Debug.Log("[Eye v2] Openness = " + eyeData.verbose_data.left.eye_openness + ", " + eyeData.verbose_data.right.eye_openness);

                        bool isLeftEyeActive = false;
                        bool isRightEyeAcitve = false;
                        if (SRanipal_Eye_Framework.Status == SRanipal_Eye_Framework.FrameworkStatus.WORKING)
                        {
                            isLeftEyeActive = eyeData.verbose_data.left.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_GAZE_ORIGIN_VALIDITY);
                            isRightEyeAcitve = eyeData.verbose_data.right.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_GAZE_ORIGIN_VALIDITY);
                        }
                        else if (SRanipal_Eye_Framework.Status == SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT)
                        {
                            isLeftEyeActive = true;
                            isRightEyeAcitve = true;
                        }

                        if (isLeftEyeActive || isRightEyeAcitve)
                        {
                            if (eye_callback_registered == true)
                                SRanipal_Eye_v2.GetEyeWeightings(out EyeWeightings, eyeData);
                            else
                                SRanipal_Eye_v2.GetEyeWeightings(out EyeWeightings);
                            UpdateEyeShapes(EyeWeightings);
                        }
                        else
                        {
                            for (int i = 0; i < (int)EyeShape.Max; ++i)
                            {
                                bool isBlink = ((EyeShape)i == EyeShape.Eye_Left_Blink || (EyeShape)i == EyeShape.Eye_Right_Blink);
                                EyeWeightings[(EyeShape)i] = isBlink ? 1 : 0;
                            }

                            UpdateEyeShapes(EyeWeightings);

                            return;
                        }

                        Vector3 GazeOriginCombinedLocal, GazeDirectionCombinedLocal = Vector3.zero;
                        if (eye_callback_registered == true)
                        {
                            if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.COMBINE, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal, eyeData)) { }
                            else if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.LEFT, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal, eyeData)) { }
                            else if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.RIGHT, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal, eyeData)) { }
                        }
                        else
                        {
                            if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.COMBINE, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal)) { }
                            else if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.LEFT, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal)) { }
                            else if (SRanipal_Eye_v2.GetGazeRay(GazeIndex.RIGHT, out GazeOriginCombinedLocal, out GazeDirectionCombinedLocal)) { }

                        }
                        UpdateGazeRay(GazeDirectionCombinedLocal);


                        AvNagonAnledningDefinierarKlasIgen(GazeDirectionCombinedLocal, GazeOriginCombinedLocal);

                    }
                }
                private void Release()
                {
                    if (eye_callback_registered == true)
                    {
                        SRanipal_Eye_v2.WrapperUnRegisterEyeDataCallback(Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));
                        eye_callback_registered = false;
                    }
                }
                private void OnDestroy()
                {
                    DestroyEyeAnchors();
                }

                public void SetEyesModels(Transform leftEye, Transform rightEye)
                {
                    if (leftEye != null && rightEye != null)
                    {
                        EyesModels = new Transform[NUM_OF_EYES] { leftEye, rightEye };
                        DestroyEyeAnchors();
                        CreateEyeAnchors();
                    }
                }

                public void SetEyeShapeTables(List<EyeShapeTable> eyeShapeTables)
                {
                    bool valid = true;
                    if (eyeShapeTables == null)
                    {
                        valid = false;
                    }
                    else
                    {
                        for (int table = 0; table < eyeShapeTables.Count; ++table)
                        {
                            if (eyeShapeTables[table].skinnedMeshRenderer == null)
                            {
                                valid = false;
                                break;
                            }
                            for (int shape = 0; shape < eyeShapeTables[table].eyeShapes.Length; ++shape)
                            {
                                EyeShape eyeShape = eyeShapeTables[table].eyeShapes[shape];
                                if (eyeShape > EyeShape.Max || eyeShape < 0)
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (valid)
                        EyeShapeTables = eyeShapeTables;
                }

                public void SetEyeShapeAnimationCurves(AnimationCurve[] eyebrowAnimationCurves)
                {
                    if (eyebrowAnimationCurves.Length == (int)EyeShape.Max)
                        EyebrowAnimationCurves = eyebrowAnimationCurves;
                }

                public void UpdateGazeRay(Vector3 gazeDirectionCombinedLocal)
                {
                    for (int i = 0; i < EyesModels.Length; ++i)
                    {
                        Vector3 target = EyeAnchors[i].transform.TransformPoint(gazeDirectionCombinedLocal);
                        EyesModels[i].LookAt(target);
                    }
                }

                public void UpdateEyeShapes(Dictionary<EyeShape, float> eyeWeightings)
                {
                    foreach (var table in EyeShapeTables)
                        RenderModelEyeShape(table, eyeWeightings);
                }

                private void RenderModelEyeShape(EyeShapeTable eyeShapeTable, Dictionary<EyeShape, float> weighting)
                {
                    for (int i = 0; i < eyeShapeTable.eyeShapes.Length; ++i)
                    {
                        EyeShape eyeShape = eyeShapeTable.eyeShapes[i];
                        if (eyeShape > EyeShape.Max || eyeShape < 0) continue;

                        if (eyeShape == EyeShape.Eye_Left_Blink || eyeShape == EyeShape.Eye_Right_Blink)
                            eyeShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(i, weighting[eyeShape] * 100f);
                        else
                        {
                            AnimationCurve curve = EyebrowAnimationCurves[(int)eyeShape];
                            eyeShapeTable.skinnedMeshRenderer.SetBlendShapeWeight(i, curve.Evaluate(weighting[eyeShape]) * 100f);
                        }
                    }
                }

                private void CreateEyeAnchors()
                {
                    EyeAnchors = new GameObject[NUM_OF_EYES];
                    for (int i = 0; i < NUM_OF_EYES; ++i)
                    {
                        EyeAnchors[i] = new GameObject();
                        EyeAnchors[i].name = "ychr" + i;
                        EyeAnchors[i].transform.SetParent(gameObject.transform);
                        EyeAnchors[i].transform.localPosition = EyesModels[i].localPosition;
                        EyeAnchors[i].transform.localRotation = EyesModels[i].localRotation;
                        EyeAnchors[i].transform.localScale = EyesModels[i].localScale;
                    }
                }

                private void DestroyEyeAnchors()
                {
                    if (EyeAnchors != null)
                    {
                        foreach (var obj in EyeAnchors)
                            if (obj != null) Destroy(obj);
                    }
                }
                private static void EyeCallback(ref EyeData_v2 eye_data)
                {
                    eyeData = eye_data;
                }

                public void KlasIsDefining()
                {
                    TESTpupilLeft = eyeData.verbose_data.left.pupil_diameter_mm;
                    TESTpupilRight = eyeData.verbose_data.right.pupil_diameter_mm;
                    TESTleftEyePositionInSensorArea = eyeData.verbose_data.left.pupil_position_in_sensor_area;
                    TESTrightEyePositionInSensorArea = eyeData.verbose_data.right.pupil_position_in_sensor_area;
                    TESTcombinedConvergenceDistanceInmm = eyeData.verbose_data.combined.convergence_distance_mm;
                    TESTleftGazeDirectionNormalized = eyeData.verbose_data.left.gaze_direction_normalized;
                    TESTrightGazeDirectionNormalized = eyeData.verbose_data.right.gaze_direction_normalized;
                    TESTleftEyeOpenness = eyeData.verbose_data.left.eye_openness;
                    TESTrightEyeOpenness = eyeData.verbose_data.right.eye_openness;
                    TESTleftGazeOrigin = eyeData.verbose_data.left.gaze_origin_mm;
                    TESTrightGazeOrigin = eyeData.verbose_data.right.gaze_origin_mm;
                    print("TESTrightGazeOrigin" + TESTrightGazeOrigin);
                    print("TESTpupilLeft" + TESTpupilLeft);

                    /// Klas made this mess
                }

                public void KlasIsSaving()
                {
                    string timestamp = System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    // string[] ninjor = { "Putte ", "Hayamoto ", "Ryu ", "Barabas" };
                    // string json = JsonUtility.ToJson(ninjor);
                    if (TaskTestSession.IntTrialNo == 1 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/TrialSessions1und2.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üUsrKyü" + KeyDownDown
                        + "üNoTapsü" + NoOfTaps
                        + "üCurTskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop 
                        + "üBlSy " + TaskTestSession.BoolSyncSlide

                    ) ;

                    }
                    if (TaskTestSession.IntTrialNo == 2 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/TrialSessions1und2.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üSpacePressedü" + KeyDownDown
                        + "üNumber of Tapsü" + NoOfTaps
                        + "üCurrentCalledTaskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                        + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                    );

                    }

                    if (TaskTestSession.IntTrialNo == 5 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/TrialSessions3und4.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üSpacePressedü" + KeyDownDown
                        + "üNumber of Tapsü" + NoOfTaps
                        + "üCurrentCalledTaskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                        + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                    );

                    }

                    if (TaskTestSession.IntTrialNo == 6 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/TrialSessions3und4.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üSpacePressedü" + KeyDownDown
                        + "üNumber of Tapsü" + NoOfTaps
                        + "üCurrentCalledTaskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                        + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                    );

                    }


                    else if (TaskTestSession.IntTrialNo == 3 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/ExpSession1.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üSpacePressedü" + KeyDownDown
                        + "üNumber of Tapsü" + NoOfTaps
                        + "üCurrentCalledTaskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                        + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                    );
                    }

                    else if (TaskTestSession.IntTrialNo == 4 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/ExpSession2.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üSpacePressedü" + KeyDownDown
                        + "üNumber of Tapsü" + NoOfTaps
                        + "üCurrentCalledTaskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                        + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                    );
                    }

                    else if (TaskTestSession.IntTrialNo == 7 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/ExpSession3.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üSpacePressedü" + KeyDownDown
                        + "üNumber of Tapsü" + NoOfTaps
                        + "üCurrentCalledTaskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                        + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                    );
                    }

                    else if (TaskTestSession.IntTrialNo == 8 && TaskTestSession.BoolTrialIsOn == true)
                    {
                        File.AppendAllText(Application.dataPath + "/FinalLog/ExpSession4.txt",
                        "ö" + TaskTestSession.IntAinc + "ü"
                        + "Mncü" + TaskTestSession.MainIncrement
                        + "üTmü" + Time.time
                        + "üITNü" + TaskTestSession.IntTrialNo
                        + "üblGoü" + TESTleftGazeOrigin
                        + "üTGroü" + TESTrightGazeOrigin
                        + "üblYPsaü" + TESTleftEyePositionInSensorArea
                        + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                        + "übplü" + TESTpupilLeft
                        + "üTrpü" + TESTpupilRight
                        + "üTlGdnü" + TESTleftGazeDirectionNormalized
                        + "übrGdnü" + TESTrightGazeDirectionNormalized
                        + "üTlYoü" + TESTleftEyeOpenness
                        + "übrYoü" + TESTrightEyeOpenness
                        + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                        + "üSpacePressedü" + KeyDownDown
                        + "üNumber of Tapsü" + NoOfTaps
                        + "üCurrentCalledTaskü" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                        + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                    );
                    }



                    if (TaskTestSession.BoolTrialIsOn == true && TaskTestSession.BoolTrialIsOn == true)
                    {
                        TaskTestSession.IntAinc++;
                        File.AppendAllText(Application.dataPath + "/LCK/EyeDataTest.txt",
                            "ö" + TaskTestSession.IntAinc + "ü"
                            + "Mncü" + TaskTestSession.MainIncrement
                            + "üTmü" + Time.time
                            + "üITNü" + TaskTestSession.IntTrialNo
                            + "üblGoü" + TESTleftGazeOrigin
                            + "üTGroü" + TESTrightGazeOrigin
                            + "üblYPsaü" + TESTleftEyePositionInSensorArea
                            + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                            + "übplü" + TESTpupilLeft
                            + "üTrpü" + TESTpupilRight
                            + "üTlGdnü" + TESTleftGazeDirectionNormalized
                            + "übrGdnü" + TESTrightGazeDirectionNormalized
                            + "üTlYoü" + TESTleftEyeOpenness
                            + "übrYoü" + TESTrightEyeOpenness
                            + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                            + "SpacePressed" + KeyDownDown + "Number of Taps" + NoOfTaps
                            + "CurrentCalledTask" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                            + "üBlSyncSl " + TaskTestSession.BoolSyncSlide

                            );




                        File.AppendAllText(Application.dataPath + "/LCK/FinalLog.htm",
                            "ö" + TaskTestSession.IntAinc + "ü"
                            + "Mncü" + TaskTestSession.MainIncrement
                            + "üTmü" + Time.time
                            + "üITNü" + TaskTestSession.IntTrialNo
                            + "üblGoü" + TESTleftGazeOrigin
                            + "üTGroü" + TESTrightGazeOrigin
                            + "üblYPsaü" + TESTleftEyePositionInSensorArea
                            + "üTrYpSoü" + TESTrightEyePositionInSensorArea
                            + "übplü" + TESTpupilLeft
                            + "üTrpü" + TESTpupilRight
                            + "üTlGdnü" + TESTleftGazeDirectionNormalized
                            + "übrGdnü" + TESTrightGazeDirectionNormalized
                            + "üTlYoü" + TESTleftEyeOpenness
                            + "übrYoü" + TESTrightEyeOpenness
                            + "üTcmcnDü" + TESTcombinedConvergenceDistanceInmm
                            + "SpacePressed" + KeyDownDown + "Number of Taps" + NoOfTaps
                            + "CurrentCalledTask" + TaskTestSession.CurrentCalledTask
                        + "üEmo" + ChangeMaterial.IncrementFearLoop
                            + "üBlSyncSl " + TaskTestSession.BoolSyncSlide
                            );
                                if (KeyDownDown == true)
                                {
                                    KeyDownDown = false;
                                    if (NoOfTaps > 0)
                                        {
                                        NoOfTaps = 0;
                                        }
                                }

                    }


                    /*                    else
                                            {
                                                File.AppendAllText(Application.dataPath + "/FinalLog/EyeDataTest.txt",
                                                    "Mncü" + TaskTestSession.MainIncrement
                                                    + "ü"
                                                    + "Tmü" + Time.time
                                                    + "ü"
                                                    + "Bk"
                                            );

                                    }*/
                    //Logging pupilometry data to FinalLOG 
                    //                    File.AppendAllText(Application.dataPath + "/FinalLog/PupilometryData.txt", "ö" + "bm" + Time.time + "ü" + "Lpmü" + TESTpupilLeft + "ü" + "Rpapü" + TESTpupilRight + "ü");

                    // string destination = Application.persistentDataPath + "Assets/Klabbe.txt";
                    // StreamWriter writer = new StreamWriter(destination, true);
                    // writer.WriteLine("Hello hey, what's your name?");
                    ///writer.Close();
                    KlasHasSaved = true;
                    // Klas did it again

//                        File.AppendAllText(Application.dataPath + "/FinalLog/KeyDown.txt",
//                        TaskTestSession.IntAinc 
//                        + "üITNü" + TaskTestSession.IntTrialNo
//                        + "üTmü" + Time.time
//                        + "üSpacePressedü" + KeyDownDown
//                    );

                }

                public void AvNagonAnledningDefinierarKlasIgen(Vector3 GazeDirectionCombinedLocal, Vector3 GazeOriginCombinedLocal)
                {
                    TESTkombineradDirektionGaze = GazeDirectionCombinedLocal;
                    TESTkombineradOriginGaze = GazeOriginCombinedLocal;
                    //Klas has done it again
                }
            }
        }
    }
}
