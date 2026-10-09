using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight_Script : MonoBehaviour
{
    // Hız ve uçuş parametreleri
    public float acceleration = 5f; // Hızlanma çarpanı
    float normalSpeed = -40f;    // Normal hız (başlangıç hızı)
    public float speed =-70f;                // Mevcut hız
    float maxSpeed = -200f;      // Maksimum hız
    float liftForce = 5f;       // Uçağın yukarı kalkış kuvveti
    float turnSpeed = -100f;      // Dönüş hızı
    float pitchSpeed = -50f;    // Yükselme/alçalma hızı
    public float maxheight= 350f;
    Boolean crashed = false;
    Boolean AccelerationBoolean = false;
    public GameObject plane;    // Uçak objesi
    public GameObject camera;
    private Vector3 targetCamPos = new Vector3(6.4f, -29.7f, -21f);
    private float smoothSpeed = 5f;
    private Boolean pressing =false;
    private Vector3 velocity= Vector3.zero;
    private void Start()
    {
        speed = normalSpeed; // Başlangıçta normal hız
    }

    void Update()
    {
        float upAlignment = Vector3.Dot(plane.transform.up, Vector3.up);
        float liftMultiplier = (upAlignment + 1f) / 2f;
        float currentLiftForce = liftForce * liftMultiplier;
        // Hızlanma (Mouse sol tuşu ile)
        if (Input.GetKey(KeyCode.Mouse0))
        {
            AccelerationBoolean= true;
            if (speed > maxSpeed && !crashed)
            {
                // Maksimum hıza yaklaştıkça hızlanma azalır
                float adjustedAcceleration = acceleration*5000 *(maxSpeed-speed)/ maxSpeed;
                speed -= adjustedAcceleration * Time.deltaTime;
            }
            else if(!crashed && speed <= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            AccelerationBoolean= false;

        }
        if(!AccelerationBoolean && speed <= -40f)
        {
            float adjustedAcceleration = acceleration * 5000 * (maxSpeed - speed) / speed;
            speed += adjustedAcceleration * Time.deltaTime;
        }
        if(pressing)
        {

        }
        // Uçak dönüşleri (Sağa ve sola)
        if (Input.GetKey(KeyCode.D))
        {
            pressing = true;
            plane.transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime); // Sol dönüş (Roll)
            camera.transform.localRotation = Quaternion.Slerp(camera.transform.localRotation, Quaternion.Euler(10, -180, 15), smoothSpeed * Time.deltaTime);
        }        
        if (Input.GetKey(KeyCode.A))
        {
            pressing = true;
            plane.transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime); // Sağ dönüş (Roll)
            camera.transform.localRotation = Quaternion.Slerp(camera.transform.localRotation, Quaternion.Euler(10, -180, -15), smoothSpeed * Time.deltaTime);
        }
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            pressing = false;
        }
        if(!pressing)
        {
            camera.transform.localRotation = Quaternion.Slerp(camera.transform.localRotation, Quaternion.Euler(10, -180, 0), smoothSpeed * Time.deltaTime);
            Vector3 camPos = camera.transform.position;

        }
        // Uçağın yükselmesi/alçalması (Pitch kontrolü)
        if (Input.GetKey(KeyCode.S))
        {
            pressing = true;
            plane.transform.Rotate(Vector3.right * -pitchSpeed * Time.deltaTime); // Yukarı bakma
            camera.transform.localRotation = Quaternion.Slerp(camera.transform.localRotation, Quaternion.Euler(25, -180, 15), smoothSpeed * Time.deltaTime);
  
        }

        if (Input.GetKey(KeyCode.W))
        {
            pressing = true;
            plane.transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime); // Aşağı bakma
            camera.transform.localRotation = Quaternion.Slerp(camera.transform.localRotation, Quaternion.Euler(-5, -180, 15), smoothSpeed * Time.deltaTime);
        
    }

        // Uçağın pozisyonunu güncelleme
        plane.transform.position += plane.transform.forward * speed * Time.deltaTime; // İleri hareket
        plane.transform.position += plane.transform.up * liftForce * Time.deltaTime;  // Yukarı hareket

        if (crashed)
        {
            camera.transform.localPosition = targetCamPos;
           
        }
        if(plane.transform.position.y>=350)

        { 
            plane.transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime); // Aşağı bakma
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!crashed)
        {
            crashed = true;
            acceleration = 0f;
            speed = 0f;
            turnSpeed = 0f;
            pitchSpeed = 0f;
            AccelerationBoolean = false;
        }
    }
}
