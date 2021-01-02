﻿using UnityEngine;
using System.Collections;

class ObjectsPool{

    ArrayList used;
    ArrayList avail;
    int size;

    public ObjectsPool()
    {
        size = 0;
        avail = null;
        used = null;
    }

    public ObjectsPool(BackgroundObject source, Transform parent, int size) {

        this.size = size;
        int index;

        for (int i = 0; i < size; i++)
        {
            
            BackgroundObject current = (BackgroundObject)Object.Instantiate(source);
            current.transform.position = new Vector3(-10.0f, 0.0f, 1.0f);
        }

        used = null;


    }


    public ObjectsPool(ForegroundObject[] source, int size) {

        this.size = size;
        int index;

        for (int i = 0; i < size; i++) {

            index = Random.Range(0, source.Length);
            ForegroundObject current = (ForegroundObject) Object.Instantiate(source[index]);
            current.transform.position = new Vector3(-15.0f, 0.0f, 1.0f);
        }
        
        used = null;
    }

    public void Instantiate(Vector3 position) {

        int index = Random.Range(0, avail.Count);

        GameObject current = (GameObject) avail[index];
        avail.RemoveAt(index);

        current.transform.position = position;

        used.Add(current);
    } 


}

