using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Tabs.AppCompat.App;
using Letter.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Letter.Views
{
    public class MainView
    {
        Context contextBoton;

        public MainView(Context context)
        {
            TableLanguage1(context);
            TableLanguage2(context);
            TableLanguage3(context);

            contextBoton = context;
            FloatingActionButton fab = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.fab_right);
            fab.Click += FabRightClick;
        }

        private void FabRightClick(object sender, EventArgs eventArgs)
        {
            RightLanguage1(contextBoton);
            RightLanguage2(contextBoton);
            RightLanguage3(contextBoton);
        }

        void TableLanguage1(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();

            List<string> frase = mainViewModel.GetSentenceSimple("lesson 1");

            TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_1);
            text_pronoun.Text = frase[0];
            TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_2);
            text_verb.Text = frase[1];
            TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_3);
            text_noun.Text = frase[2];
        }

        void TableLanguage2(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();

            List<string> frase = mainViewModel.GetSentenceSimple("lektion 1");

            TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_1);
            text_pronoun.Text = frase[0];
            TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_2);
            text_verb.Text = frase[1];
            TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_3);
            text_noun.Text = frase[2];
        }

        void TableLanguage3(Context context)
        {
            MainViewModel mainViewModel = new MainViewModel();

            List<string> frase = mainViewModel.GetSentenceSimple("lezione 1");

            TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_1);
            text_pronoun.Text = frase[0];
            TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_2);
            text_verb.Text = frase[1];
            TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_3);
            text_noun.Text = frase[2];
        }


        public MainViewModel _mainViewModel = new MainViewModel();
        int lesson_number = 1;

        void RightLanguage1(Context context)
        {
            String lesson="";
            int exit = 0;
            List<string> frase;
            do
            {
                lesson_number++;
                lesson = "lesson " + lesson_number;
                frase = _mainViewModel.GetSentenceSimple(lesson);
                exit++;
                if (exit == 10) break;
            } while (frase == null);

            if (exit == 10)
            {
                lesson_number = 1;
                lesson = "lesson " + lesson_number;
                frase = _mainViewModel.GetSentenceSimple(lesson);
            } 

            TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_1);
            text_pronoun.Text = frase[0];
            TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_2);
            text_verb.Text = frase[1];
            TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_3);
            text_noun.Text = frase[2];
       }

        int lektion_number = 1;
        void RightLanguage2(Context context)
        {
            String lesson = "";
            int exit = 0;
            List<string> frase;
            do
            {
                lektion_number++;
                lesson = "lektion " + lektion_number;
                frase = _mainViewModel.GetSentenceSimple(lesson);
                exit++;
                if (exit == 10) break;
            } while (frase == null);

            if (exit == 10)
            {
                lektion_number = 1;
                lesson = "lektion " + lektion_number;
                frase = _mainViewModel.GetSentenceSimple(lesson);
            }

            TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_1);
            text_pronoun.Text = frase[0];
            TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_2);
            text_verb.Text = frase[1];
            TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_3);
            text_noun.Text = frase[2];
        }

        int lezione_number = 1;
        void RightLanguage3(Context context)
        {
            String lesson = "";
            int exit = 0;
            List<string> frase;
            do
            {
                lezione_number++;
                lesson = "lezione " + lezione_number;
                frase = _mainViewModel.GetSentenceSimple(lesson);
                exit++;
                if (exit == 10) break;
            } while (frase == null);

            if (exit == 10)
            {
                lezione_number = 1;
                lesson = "lezione " + lezione_number;
                frase = _mainViewModel.GetSentenceSimple(lesson);
            }

            TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_1);
            text_pronoun.Text = frase[0];
            TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_2);
            text_verb.Text = frase[1];
            TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_3);
            text_noun.Text = frase[2];
        }

    }

}