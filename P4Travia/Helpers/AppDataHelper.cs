﻿using Android.App;
using Android.Content;
using Firebase.Firestore;
using Firebase.Auth;
using Firebase;

//This connects our project to Firestore Database and Authenticator

namespace P4Travia.Helpers
{
    public static class AppDataHelper
    {

        static ISharedPreferences preferences = Application.Context.GetSharedPreferences("userinfo", FileCreationMode.Private);
        static ISharedPreferencesEditor editor;

        //This is connects to the database

        public static FirebaseFirestore GetFirestore()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseFirestore database;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()

                    .SetProjectId("Removed for showcasing")
                    .SetApplicationId("Removed for showcasing")
                    .SetApiKey("Removed for showcasing")
                    .SetStorageBucket("Removed for showcasing")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseFirestore.GetInstance(app);

            }
            else
            {
                database = FirebaseFirestore.GetInstance(app);
            }

            return database;
        }


        //This connects to the Athenticator
        public static FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth mAuth;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()

                    .SetProjectId("Removed for showcasing")
                    .SetApplicationId("Removed for showcasing")
                    .SetApiKey("Removed for showcasing")
                    .SetStorageBucket("Removed for showcasing")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                mAuth = FirebaseAuth.Instance;

            }
            else
            {
                mAuth = FirebaseAuth.Instance;
            }

            return mAuth;
        }


        //Method for saving the users name when opening the app (Other parameters can be added)
        public static void SaveName(string name)
        {
            editor = preferences.Edit();
            editor.PutString("name", name);
            editor.Apply();
        }

        //Retrieves the users name when opening the app (Other parameters can be added)
        public static string GetName()
        {

            string name = preferences.GetString("name", "");
            return name;
        }
    }
}