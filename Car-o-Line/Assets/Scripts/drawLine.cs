using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drawLine : MonoBehaviour
{
    //This code handles with Drawing Line and Wheel settings of the Line
    
    public GameObject linePrefab;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;

    GameObject camera;
    Vector3 Distance;
    Vector3 camPos;
    public bool camFollow;

    [SerializeField] GameObject backTire;
    [SerializeField] GameObject frontTire;
    public GameObject carTire1;
    public GameObject carTire2;

    public JointMotor2D jointMotor2D;
    public float motorSpeed;

    void Start()
    {
        camFollow = true;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        backTire.GetComponent<WheelJoint2D>().useMotor = true;
        frontTire.GetComponent<WheelJoint2D>().useMotor = true;

        PlayerPrefs.SetString("PreviousScene",SceneManager.GetActiveScene().name);

        Time.timeScale = 1;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            if (currentLine)
            {
                Destroy(currentLine);
            }
            
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
            {
                UpdateLine(tempFingerPos);
                //Instantiate(carWheel, lineRenderer.GetPosition(lineRenderer.positionCount - 1), Quaternion.identity);
            }

        }

        WheelSpawner();

    }
    void LateUpdate()
    {
        if (currentLine && camFollow)
        {
            CamKontrol();
        }
        
    }
    void CreateLine() // Creates line and Adds collider
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        Distance = camera.transform.position - currentLine.transform.position;
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
        

    }
    void UpdateLine(Vector2 newFingerPos) // Ads finger touch control
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
   

    }
    void CamKontrol() // Camera follows the line we drew
    {
        camPos = Distance + currentLine.transform.position;
        camera.transform.position = new Vector3(camPos.x, camera.transform.position.y, camPos.z);
    }
    void WheelSpawner() //It spawns wheels in starting and ending points of the Line
    {
        if (currentLine)
        {
        
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(carTire1);
                carTire1 =Instantiate(backTire, lineRenderer.GetPosition(0), Quaternion.Euler(0, 90, 0));
                carTire1.GetComponent<WheelJoint2D>().connectedBody = currentLine.GetComponent<Rigidbody2D>();
                carTire1.GetComponent<WheelJoint2D>().connectedAnchor = lineRenderer.GetPosition(0);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Destroy(carTire2);
                carTire2 =Instantiate(frontTire, lineRenderer.GetPosition(lineRenderer.positionCount - 1), Quaternion.Euler(0, 90, 0));
                carTire2.GetComponent<WheelJoint2D>().connectedBody = currentLine.GetComponent<Rigidbody2D>();
                carTire2.GetComponent<WheelJoint2D>().connectedAnchor = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
            }
            
        }
        
    }
    public void SpeedtheCar()
    {
        motorSpeed = 1500f;
        jointMotor2D.motorSpeed = motorSpeed;
        jointMotor2D.maxMotorTorque = 10000;
        carTire1.GetComponent<WheelJoint2D>().motor = jointMotor2D;
        carTire2.GetComponent<WheelJoint2D>().motor = jointMotor2D;
    }

}
