using Android.App;
using Android.Content;
using Android.Widget;
using CRUD.Models;
using Google.Android.Material.FloatingActionButton;
using Letter.Models;
using Letter.ViewsModels;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Letter.Views
{
    public class MainView 
    {
        Context contextBoton;

        private List<FraseModel> _lesson_english;
        private List<FraseModel> _lesson_deutsch;
        private List<FraseModel> _lesson_italiano;
        private List<FraseModel> _lesson_francais;
        private List<FraseModel> _lesson_espanol;

        FraseModel _english;
        FraseModel _deutsch;
        FraseModel _italiano;
        FraseModel _francais;
        FraseModel _espanol;

        string _english_verb;
        string _english_noun;
        string _english_pronoun;
        string _deutsch_verb;
        string _deutsch_noun;
        string _italiano_verb;
        string _italiano_noun;
        string _francais_verb;
        string _francais_noun;
        string _espanol_verb;
        string _espanol_noun;

        bool pause1 = false;
        bool pause2 = false;
        bool pause3 = false;
        bool pause4 = false;
        bool pause5 = false;

        public MainViewModel _mainViewModel = new MainViewModel();

        public int VIEW_TYPE_SEND = 1;
        public int VIEW_TYPE_RECEIVED = 2;

        private List<EstoutroModel> _pronoun_english;

        public MainView(Context context)
        {
//---
            _lesson_english = _mainViewModel.GetLessonSimple("english").Distinct().ToList();
            _lesson_deutsch = _mainViewModel.GetLessonSimple("deutsch").Distinct().ToList();
            _lesson_italiano = _mainViewModel.GetLessonSimple("italiano").Distinct().ToList();
            _lesson_francais = _mainViewModel.GetLessonSimple("français").Distinct().ToList();
            _lesson_espanol = _mainViewModel.GetLessonSimple("espanõl").Distinct().ToList();
//---
            _english_verb = null;
            _english_noun = null;
            _deutsch_verb = null;
            _deutsch_noun = null;
            _italiano_verb = null;
            _italiano_noun = null;
            _francais_verb = null;
            _francais_noun = null;
            _espanol_verb = null;
            _espanol_noun = null;
            //---
            _pronoun_english = _mainViewModel.GetPronoun("english");
//---

            NextEnglish(context);
            NextDeutsch(context);
            NextItaliano(context);
            NextFrancais(context);
            NextEspanol(context);
            //---
            contextBoton = context;
            FloatingActionButton fab_right = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.fab_right);
            fab_right.Click += FabRightClick;
//---
            FloatingActionButton fab_left = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.fab_left);
            fab_left.Click += FabLeftClick;
//---
            FloatingActionButton fab_up = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.fab_up);
            fab_up.Click += FabUpClick;
//---
            FloatingActionButton fab_down = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.fab_down);
            fab_down.Click += FabDownClick;
//---
            FloatingActionButton fab_pause1 = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.floating_behind_1);
            fab_pause1.Click += FabPause1Click;
            //---
            FloatingActionButton fab_pause2 = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.floating_behind_2);
            fab_pause2.Click += FabPause2Click;
//---
            FloatingActionButton fab_pause3 = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.floating_behind_3);
            fab_pause3.Click += FabPause3Click;
//---
            FloatingActionButton fab_pause4 = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.floating_behind_4);
            fab_pause4.Click += FabPause4Click;
//---
            FloatingActionButton fab_pause5 = (FloatingActionButton)((Activity)context).FindViewById(Resource.Id.floating_behind_5);
            fab_pause5.Click += FabPause5Click;
        }

        private void FabPause5Click(object sender, EventArgs e)
        {
            FloatingActionButton fab_pause5 = (FloatingActionButton)((Activity)contextBoton).FindViewById(Resource.Id.floating_behind_5);
            if (pause5 == false)
            {
                fab_pause5.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_play));
                pause5 = true;
            }
            else
            {
                fab_pause5.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_pause));
                pause5 = false;
            }
        }

        private void FabPause4Click(object sender, EventArgs e)
        {
            FloatingActionButton fab_pause4 = (FloatingActionButton)((Activity)contextBoton).FindViewById(Resource.Id.floating_behind_4);
            if (pause4 == false)
            {
                fab_pause4.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_play));
                pause4 = true;
            }
            else
            {
                fab_pause4.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_pause));
                pause4 = false;
            }
        }

        private void FabPause3Click(object sender, EventArgs e)
        {
            FloatingActionButton fab_pause3 = (FloatingActionButton)((Activity)contextBoton).FindViewById(Resource.Id.floating_behind_3);
            if (pause3 == false)
            {
                fab_pause3.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_play));
                pause3 = true;
            }
            else
            {
                fab_pause3.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_pause));
                pause3 = false;
            }

        }

        private void FabPause2Click(object sender, EventArgs e)
        {
            FloatingActionButton fab_pause2 = (FloatingActionButton)((Activity)contextBoton).FindViewById(Resource.Id.floating_behind_2);
            if (pause2 == false)
            {
                fab_pause2.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_play));
                pause2 = true;
            }
            else
            {
                fab_pause2.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_pause));
                pause2 = false;
            }
        }

        private void FabPause1Click(object sender, EventArgs e)
        {
            FloatingActionButton fab_pause1 = (FloatingActionButton)((Activity)contextBoton).FindViewById(Resource.Id.floating_behind_1);
            if (pause1 == false)
            {
                fab_pause1.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_play));
                pause1 = true;
            }
            else
            {
                fab_pause1.SetImageDrawable(contextBoton.GetDrawable(Resource.Drawable.ic_pause));
                pause1 = false;
            }
        }

        private void FabRightClick(object sender, EventArgs eventArgs)
        {
            NextEnglish(contextBoton);
            NextDeutsch(contextBoton);
            NextItaliano(contextBoton);
            NextFrancais(contextBoton);
            NextEspanol(contextBoton);
        }

        private void FabLeftClick(object sender, EventArgs eventArgs)
        {
            PreviousEnglish(contextBoton);
            PreviousDeutsch(contextBoton);
            PreviousItaliano(contextBoton);
            PreviousFrancais(contextBoton);
            PreviousEspanol(contextBoton);
        }

        private void FabUpClick(object sender, EventArgs eventArgs)
        {
            UpEnglish(contextBoton);
            UpDeutsch(contextBoton);
            UpItaliano(contextBoton);
            UpFrancais(contextBoton);
            UpEspanol(contextBoton);
        }

        private void FabDownClick(object sender, EventArgs eventArgs)
        {
            DownEnglish(contextBoton);
            DownDeutsch(contextBoton);
            DownItaliano(contextBoton);
            DownFrancais(contextBoton);
            DownEspanol(contextBoton);
        }

        void UpEnglish(Context context)
        {
            if (pause1)
            {
//---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_2);
                int value_verb = _english.conteudo.verbo.Distinct().ToList().IndexOf(_english_verb) - 1;
                if (value_verb == -1) value_verb = 0;
                if (_english.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _english.conteudo.verbo.Distinct().ToList().Count) value_verb = _english.conteudo.verbo.Distinct().ToList().IndexOf(_english_verb);
                    _english_verb = _english.conteudo.verbo[value_verb];
                    text_verb.Text = _english_verb;
                }
//---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_3);
                int value_noun = _english.conteudo.substantivo.Distinct().ToList().IndexOf(_english_noun) - 1;
                if (value_noun == -1) value_noun = 0;
                if (_english.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _english.conteudo.substantivo.Distinct().ToList().Count) value_noun = _english.conteudo.substantivo.Distinct().ToList().IndexOf(_english_noun);
                    _english_noun = _english.conteudo.substantivo[value_noun];
                    text_noun.Text = _english_noun;
                }
                //---
                //TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_1);
           
            }
}

        void NextEnglish(Context context)
        {
            if (!pause1)
            {
                int value = _lesson_english.IndexOf(_english) + 1;
                if (value == _lesson_english.Count) value = _lesson_english.IndexOf(_english);
                if (_lesson_english.Count != 0)
                {
                    //---                    
                    _english = _lesson_english[value];
                    //---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_2);
                    _english_verb = _english.conteudo.verbo[0];
                    text_verb.Text = _english.conteudo.verbo[0];
                    //---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_3);
                    _english_noun = _english.conteudo.substantivo[0];
                    text_noun.Text = _english.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_1);
                    AsyncContext.Run(() => GetPronomeAsync(_english_verb, "english", text_pronoun));
                }
            }
        }

        void PreviousEnglish(Context context)
        {
            if (!pause1)
            {
                int value = _lesson_english.IndexOf(_english) - 1;
                if (value == -1) value = 0;
                if (_lesson_english.Count != 0)
                {
//---
                    _english = _lesson_english[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_2);
                    text_verb.Text = _english.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_3);
                    text_noun.Text = _english.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_1);
                    AsyncContext.Run(() => GetPronomeAsync(_english_verb, "english", text_pronoun));
                }
            }
        }

        void DownEnglish(Context context)
        {
            if (pause1)
            {
//---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_2);
                int value_verb = _english.conteudo.verbo.Distinct().ToList().IndexOf(_english_verb) + 1;
                if (value_verb == -1) value_verb = 0;
                if (_english.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _english.conteudo.verbo.Distinct().ToList().Count) value_verb = _english.conteudo.verbo.Distinct().ToList().IndexOf(_english_verb);
                    _english_verb = _english.conteudo.verbo[value_verb];
                    text_verb.Text = _english_verb;
                }
//---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_1_3);
                int value_noun = _english.conteudo.substantivo.Distinct().ToList().IndexOf(_english_noun) + 1;
                if (value_noun == -1) value_noun = 0;
                if (_english.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _english.conteudo.substantivo.Distinct().ToList().Count) value_noun = _english.conteudo.substantivo.Distinct().ToList().IndexOf(_english_noun);
                    _english_noun = _english.conteudo.substantivo[value_noun];
                    text_noun.Text = _english_noun;
                }
            }
        }

        void UpDeutsch(Context context)
        {
            if (pause2)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_2);
                int value_verb = _deutsch.conteudo.verbo.Distinct().ToList().IndexOf(_deutsch_verb) - 1;
                if (value_verb == -1) value_verb = 0;
                if (_deutsch.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _deutsch.conteudo.verbo.Distinct().ToList().Count) value_verb = _deutsch.conteudo.verbo.Distinct().ToList().IndexOf(_deutsch_verb);
                    _deutsch_verb = _deutsch.conteudo.verbo[value_verb];
                    text_verb.Text = _deutsch_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_3);
                int value_noun = _deutsch.conteudo.substantivo.Distinct().ToList().IndexOf(_deutsch_noun) - 1;
                if (value_noun == -1) value_noun = 0;
                if (_deutsch.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _deutsch.conteudo.substantivo.Distinct().ToList().Count) value_noun = _deutsch.conteudo.substantivo.Distinct().ToList().IndexOf(_deutsch_noun);
                    _deutsch_noun = _deutsch.conteudo.substantivo[value_noun];
                    text_noun.Text = _deutsch_noun;
                }
            }
        }

        void NextDeutsch(Context context)
        {
            if (!pause2)
            {
                int value = _lesson_deutsch.IndexOf(_deutsch) + 1;
                if (value == _lesson_deutsch.Count) value = _lesson_deutsch.IndexOf(_deutsch);
                if (_lesson_deutsch.Count != 0)
                {
//---
                    _deutsch = _lesson_deutsch[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_2);
                    _deutsch_verb = _deutsch.conteudo.verbo[0];
                    text_verb.Text = _deutsch.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_3);
                    _deutsch_noun = _deutsch.conteudo.substantivo[0];
                    text_noun.Text = _deutsch.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_1);
                    AsyncContext.Run(() => GetPronomeAsync(_deutsch_verb, "deutsch", text_pronoun));
                }
            }
        }

        void PreviousDeutsch(Context context)
        {
            if (!pause2)
            {
                int value = _lesson_deutsch.IndexOf(_deutsch) - 1;
                if (value == -1) value = 0;
                if (_lesson_deutsch.Count != 0)
                {
//---
                    _deutsch = _lesson_deutsch[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_2);
                    _deutsch_verb = _deutsch.conteudo.verbo[0];
                    text_verb.Text = _deutsch.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_3);
                    _deutsch_noun = _deutsch.conteudo.substantivo[0];
                    text_noun.Text = _deutsch.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_1);
                    AsyncContext.Run(() => GetPronomeAsync(_deutsch_verb, "deutsch", text_pronoun));
                }
            }
        }

        void DownDeutsch(Context context)
        {
            if (pause2)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_2);
                int value_verb = _deutsch.conteudo.verbo.Distinct().ToList().IndexOf(_deutsch_verb) + 1;
                if (value_verb == -1) value_verb = 0;
                if (_deutsch.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _deutsch.conteudo.verbo.Distinct().ToList().Count) value_verb = _deutsch.conteudo.verbo.Distinct().ToList().IndexOf(_deutsch_verb);
                    _deutsch_verb = _deutsch.conteudo.verbo[value_verb];
                    text_verb.Text = _deutsch_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_2_3);
                int value_noun = _deutsch.conteudo.substantivo.Distinct().ToList().IndexOf(_deutsch_noun) + 1;
                if (value_noun == -1) value_noun = 0;
                if (_deutsch.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _deutsch.conteudo.substantivo.Distinct().ToList().Count) value_noun = _deutsch.conteudo.substantivo.IndexOf(_deutsch_noun);
                    _deutsch_noun = _deutsch.conteudo.substantivo[value_noun];
                    text_noun.Text = _deutsch_noun;
                }
            }
        }

        void UpItaliano(Context context)
        {
            if (pause3)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_2);
                int value_verb = _italiano.conteudo.verbo.Distinct().ToList().IndexOf(_italiano_verb) - 1;
                if (value_verb == -1) value_verb = 0;
                if (_italiano.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _english.conteudo.verbo.Distinct().ToList().Count) value_verb = _italiano.conteudo.verbo.Distinct().ToList().IndexOf(_italiano_verb);
                    _italiano_verb = _italiano.conteudo.verbo[value_verb];
                    text_verb.Text = _italiano_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_3);
                int value_noun = _italiano.conteudo.substantivo.Distinct().ToList().IndexOf(_italiano_noun) - 1;
                if (value_noun == -1) value_noun = 0;
                if (_italiano.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _italiano.conteudo.substantivo.Distinct().ToList().Count) value_noun = _italiano.conteudo.substantivo.Distinct().ToList().IndexOf(_italiano_noun);
                    _italiano_noun = _italiano.conteudo.substantivo[value_noun];
                    text_noun.Text = _italiano_noun;
                }
            }
        }

        void NextItaliano(Context context)
        {
            if (!pause3)
            {
                int value = _lesson_italiano.IndexOf(_italiano) + 1;
                if (value == _lesson_italiano.Count) value = _lesson_italiano.IndexOf(_italiano);
                if (_lesson_italiano.Count != 0)
                {
//---
                    _italiano = _lesson_italiano[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_2);
                    _italiano_verb = _italiano.conteudo.verbo[0];
                    text_verb.Text = _italiano.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_3);
                    _italiano_noun = _italiano.conteudo.substantivo[0];
                    text_noun.Text = _italiano.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_1);
                    AsyncContext.Run(() => GetPronomeAsync(_italiano_verb, "italiano", text_pronoun));
                }
            }
        }

        void PreviousItaliano(Context context)
        {
            if (!pause3)
            {
                int value = _lesson_italiano.IndexOf(_italiano) - 1;
                if (value == -1) value = 0;
                if (_lesson_italiano.Count != 0)
                {
//---
                    _italiano = _lesson_italiano[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_2);
                    _italiano_verb = _italiano.conteudo.verbo[0];
                    text_verb.Text = _italiano.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_3);
                    _italiano_noun = _italiano.conteudo.substantivo[0];
                    text_noun.Text = _italiano.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_1);
                    AsyncContext.Run(() => GetPronomeAsync(_italiano_verb, "italiano", text_pronoun));
                }
            }
        }

        void DownItaliano(Context context)
        {
            if (pause3)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_2);
                int value_verb = _italiano.conteudo.verbo.Distinct().ToList().IndexOf(_italiano_verb) + 1;
                if (value_verb == -1) value_verb = 0;
                if (_italiano.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _italiano.conteudo.verbo.Distinct().ToList().Count) value_verb = _italiano.conteudo.verbo.Distinct().ToList().IndexOf(_italiano_verb);
                    _italiano_verb = _italiano.conteudo.verbo[value_verb];
                    text_verb.Text = _italiano_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_3_3);
                int value_noun = _italiano.conteudo.substantivo.Distinct().ToList().IndexOf(_italiano_noun) + 1;
                if (value_noun == -1) value_noun = 0;
                if (_italiano.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _italiano.conteudo.substantivo.Distinct().ToList().Count) value_noun = _italiano.conteudo.substantivo.Distinct().ToList().IndexOf(_italiano_noun);
                    _italiano_noun = _italiano.conteudo.substantivo[value_noun];
                    text_noun.Text = _italiano_noun;
                }
            }
        }

        void UpFrancais(Context context)
        {
            if (pause4)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_2);
                int value_verb = _francais.conteudo.verbo.Distinct().ToList().IndexOf(_francais_verb) - 1;
                if (value_verb == -1) value_verb = 0;
                if (_francais.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _francais.conteudo.verbo.Distinct().ToList().Count) value_verb = _francais.conteudo.verbo.Distinct().ToList().IndexOf(_francais_verb);
                    _francais_verb = _francais.conteudo.verbo[value_verb];
                    text_verb.Text = _francais_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_3);
                int value_noun = _francais.conteudo.substantivo.Distinct().ToList().IndexOf(_francais_noun) - 1;
                if (value_noun == -1) value_noun = 0;
                if (_francais.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _francais.conteudo.substantivo.Distinct().ToList().Count) value_noun = _francais.conteudo.substantivo.Distinct().ToList().IndexOf(_francais_noun);
                    _francais_noun = _francais.conteudo.substantivo[value_noun];
                    text_noun.Text = _francais_noun;
                }
            }
        }

        void NextFrancais(Context context)
        {
            if (!pause4)
            { 
                int value = _lesson_francais.IndexOf(_francais) + 1;
                if (value == _lesson_francais.Count) value = _lesson_francais.IndexOf(_francais);
                if (_lesson_francais.Count != 0)
                {
//---
                    _francais = _lesson_francais[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_2);
                    _francais_verb = _francais.conteudo.verbo[0];
                    text_verb.Text = _francais.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_3);
                    _francais_noun = _francais.conteudo.substantivo[0];
                    text_noun.Text = _francais.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_1);
                    AsyncContext.Run(() => GetPronomeAsync(_francais_verb, "francais", text_pronoun));
                }
            }
        }

        void PreviousFrancais(Context context)
        {
            if (!pause4)
            {
                int value = _lesson_francais.IndexOf(_francais) - 1;
                if (value == -1) value = 0;
                if (_lesson_francais.Count != 0)
                {
//---
                    _francais = _lesson_francais[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_2);
                    _francais_verb = _francais.conteudo.verbo[0];
                    text_verb.Text = _francais.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_3);
                    _francais_noun = _francais.conteudo.substantivo[0];
                    text_noun.Text = _francais.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_1);
                    AsyncContext.Run(() => GetPronomeAsync(_francais_verb, "francais", text_pronoun));
                }
            }
        }

        void DownFrancais(Context context)
        {
            if (pause4)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_2);
                int value_verb = _francais.conteudo.verbo.Distinct().ToList().IndexOf(_francais_verb) + 1;
                if (_francais.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _francais.conteudo.verbo.Distinct().ToList().Count) value_verb = _francais.conteudo.verbo.Distinct().ToList().IndexOf(_francais_verb);
                    _francais_verb = _francais.conteudo.verbo[value_verb];
                    text_verb.Text = _francais_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_4_3);
                int value_noun = _francais.conteudo.substantivo.Distinct().ToList().IndexOf(_francais_noun) + 1;
                if (_francais.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _francais.conteudo.substantivo.Distinct().ToList().Count) value_noun = _francais.conteudo.substantivo.Distinct().ToList().IndexOf(_francais_noun);
                    _francais_noun = _francais.conteudo.substantivo[value_noun];
                    text_noun.Text = _francais_noun;
                }
            }
        }

        void UpEspanol(Context context)
        {
            if (pause5)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_2);
                int value_verb = _espanol.conteudo.verbo.Distinct().ToList().IndexOf(_espanol_verb) - 1;
                if (value_verb == -1) value_verb = 0;
                if (_espanol.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _espanol.conteudo.verbo.Distinct().ToList().Count) value_verb = _espanol.conteudo.verbo.Distinct().ToList().IndexOf(_espanol_verb);
                    _espanol_verb = _espanol.conteudo.verbo[value_verb];
                    text_verb.Text = _espanol_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_3);
                int value_noun = _espanol.conteudo.substantivo.Distinct().ToList().IndexOf(_espanol_noun) - 1;
                if (value_noun == -1) value_noun = 0;
                if (_espanol.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _espanol.conteudo.substantivo.Distinct().ToList().Count) value_noun = _espanol.conteudo.substantivo.Distinct().ToList().IndexOf(_espanol_noun);
                    _espanol_noun = _espanol.conteudo.substantivo[value_noun];
                    text_noun.Text = _espanol_noun;
                }
            }
        }

        void NextEspanol(Context context)
        {
            if (!pause5)
            {
                int value = _lesson_espanol.IndexOf(_espanol) + 1;
                if (value == _lesson_espanol.Count) value = _lesson_espanol.IndexOf(_espanol);
                if (_lesson_espanol.Count != 0)
                {
//---
                    _espanol = _lesson_espanol[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_2);
                    _espanol_verb = _espanol.conteudo.verbo[0];
                    text_verb.Text = _espanol.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_3);
                    _espanol_noun = _espanol.conteudo.substantivo[0];
                    text_noun.Text = _espanol.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_1);
                    AsyncContext.Run(() => GetPronomeAsync(_espanol_verb, "_espanol", text_pronoun));
                }
            }
        }

        void PreviousEspanol(Context context)
        {
            if (!pause5)
            {
                int value = _lesson_espanol.IndexOf(_espanol) - 1;
                if (value == -1) value = 0;
                if (_lesson_espanol.Count != 0)
                {
//---
                    _espanol = _lesson_espanol[value];
//---
                    TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_2);
                    _espanol_verb = _espanol.conteudo.verbo[0];
                    text_verb.Text = _espanol.conteudo.verbo[0];
//---
                    TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_3);
                    _espanol_noun = _espanol.conteudo.substantivo[0];
                    text_noun.Text = _espanol.conteudo.substantivo[0];
                    //---
                    TextView text_pronoun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_1);
                    AsyncContext.Run(() => GetPronomeAsync(_espanol_verb, "_espanol", text_pronoun));
                }
            }
        }

        void DownEspanol(Context context)
        {
            if (pause5)
            {
                //---
                TextView text_verb = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_2);
                int value_verb = _espanol.conteudo.verbo.Distinct().ToList().IndexOf(_espanol_verb) + 1;
                if (value_verb == -1) value_verb = 0;
                if (_espanol.conteudo.verbo.Count != 0)
                {
                    if (value_verb == _espanol.conteudo.verbo.Distinct().ToList().Count) value_verb = _espanol.conteudo.verbo.Distinct().ToList().IndexOf(_espanol_verb);
                    _espanol_verb = _espanol.conteudo.verbo[value_verb];
                    text_verb.Text = _espanol_verb;
                }
                //---
                TextView text_noun = (TextView)((Activity)context).FindViewById(Resource.Id.txt_viw_box_5_3);
                int value_noun = _espanol.conteudo.substantivo.Distinct().ToList().IndexOf(_espanol_noun) + 1;
                if (value_noun == -1) value_noun = 0;
                if (_espanol.conteudo.substantivo.Count != 0)
                {
                    if (value_noun == _espanol.conteudo.substantivo.Distinct().ToList().Count) value_noun = _espanol.conteudo.substantivo.Distinct().ToList().IndexOf(_espanol_noun);
                    _espanol_noun = _espanol.conteudo.substantivo[value_noun];
                    text_noun.Text = _espanol_noun;
                }
            }
        }

        private async void GetPronomeAsync(string verb, string language, TextView vpronoun)
        {
            //---
            TextView text_pronoun = vpronoun;
//---
            List<EstoutroModel> pronoun = _pronoun_english.FindAll(index => index.tipo.Contains("pessoal")).ToList<EstoutroModel>();
            for (int i = 0; pronoun.Count > i; i++)
            {
//---
                ResponseModel value = await _mainViewModel.AgreePronome(pronoun[i].nome, _english_verb, "english");
/*
                if (value)
                {
//---
                    _english_pronoun = pronoun[i].nome;
                    text_pronoun.Text = pronoun[i].nome;
                    break;
                }
*/
            }

        }

    }

}