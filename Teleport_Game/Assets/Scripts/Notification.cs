using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class Notification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        StartNotification();
    }

    private void Initialize()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "channel 1",
            Name = "Test channel",
            Description = "Test notification",
            Importance = Importance.High,
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    private void StartNotification()
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Notification!";
        notification.Text = "The game has been started";
        notification.LargeIcon = "my_large_icon";
        notification.FireTime = System.DateTime.Now.AddSeconds(5);

        AndroidNotificationCenter.SendNotification(notification, "channel 1");
    }


    public void QuitNotification()
    {
        AndroidNotification quitNotification = new AndroidNotification();
        quitNotification.Title = "Allert!!!";
        quitNotification.Text = "Where are you?"+"\n"+"We miss you so much";
        quitNotification.LargeIcon = "my_large_icon";
        quitNotification.FireTime = System.DateTime.Now.AddSeconds(30);

        AndroidNotificationCenter.SendNotification(quitNotification, "channel 1");
    }
}
