using Android.App;
using Android.Content;
using Android.Widget;
using Google.Android.Material.FloatingActionButton;
using Letter.Models;
using Letter.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Letter.Views
{
    public class MainView 
    {
        //---
        Context contextBoton;
        //---
        private List<FraseModel> _lesson_english;
        private List<FraseModel> _lesson_deutsch;
        private List<FraseModel> _lesson_italiano;
        private List<FraseModel> _lesson_francais;
        private List<FraseModel> _lesson_espanol;
        //---
        FraseModel _english;
        FraseModel _deutsch;
        FraseModel _italiano;
        FraseModel _francais;
        FraseModel _espanol;
        //---
        private bool pause1 = false;
        private bool pause2 = false;
        private bool pause3 = false;
        private bool pause4 = false;
        private bool pause5 = false;
        //---
        private string ENGLISH = "english";
        private string DEUTSCH = "deutsch";
        private string ITALIANO = "italiano";
        private string FRANCAIS = "français";
        private string ESPANOL = "espanõl";
        //---
        private string VAR_SUBJECT = "sujeito";
        private string VAR_PREDICATE = "predicado";
        private string VAR_PRONOUN = "pronome";
        private string VAR_NOUN = "substantivo";
        private string VAR_VERB = "verbo";
        //---
        private List<WordModel> _word_english = new List<WordModel>();
        private List<WordModel> _word_deutsch = new List<WordModel>();
        private List<WordModel> _word_italiano = new List<WordModel>();
        private List<WordModel> _word_francais = new List<WordModel>();
        private List<WordModel> _word_espanol = new List<WordModel>();
        //---
        public MainViewModel _mainViewModel = new MainViewModel();

        public MainView(Context context)
        {
            //---
            _lesson_english = _mainViewModel.GetLessonSimple("english").Distinct().ToList();
            _lesson_deutsch = _mainViewModel.GetLessonSimple("deutsch").Distinct().ToList();
            _lesson_italiano = _mainViewModel.GetLessonSimple("italiano").Distinct().ToList();
            _lesson_francais = _mainViewModel.GetLessonSimple("français").Distinct().ToList();
            _lesson_espanol = _mainViewModel.GetLessonSimple("espanõl").Distinct().ToList();
            //---
            Next(context, _lesson_english, _english, ENGLISH);
            Next(context, _lesson_deutsch, _deutsch, DEUTSCH);
            Next(context, _lesson_italiano, _italiano, ITALIANO);
            Next(context, _lesson_francais, _francais, FRANCAIS);
            Next(context, _lesson_espanol, _espanol, ESPANOL);
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
            Next(contextBoton, _lesson_english, _english, ENGLISH);
            Next(contextBoton, _lesson_deutsch, _deutsch, DEUTSCH);
            Next(contextBoton, _lesson_italiano, _italiano, ITALIANO);
            Next(contextBoton, _lesson_francais, _francais, FRANCAIS);
            Next(contextBoton, _lesson_espanol, _espanol, ESPANOL);
        }

        private void FabLeftClick(object sender, EventArgs eventArgs)
        {
            Previous(contextBoton, _lesson_english, _english, ENGLISH);
            Previous(contextBoton, _lesson_deutsch, _deutsch, DEUTSCH);
            Previous(contextBoton, _lesson_italiano, _italiano, ITALIANO);
            Previous(contextBoton, _lesson_francais, _francais, FRANCAIS);
            Previous(contextBoton, _lesson_espanol, _espanol, ESPANOL);
        }

        private void FabDownClick(object sender, EventArgs eventArgs)
        {
            Down(contextBoton, _lesson_english, _english, ENGLISH, _word_english);
            Down(contextBoton, _lesson_deutsch, _deutsch, DEUTSCH, _word_deutsch);
            Down(contextBoton, _lesson_italiano, _italiano, ITALIANO, _word_italiano);
            Down(contextBoton, _lesson_francais, _francais, FRANCAIS, _word_francais);
            Down(contextBoton, _lesson_espanol, _espanol, ESPANOL, _word_espanol);
        }

        private void FabUpClick(object sender, EventArgs eventArgs)
        {
            Up(contextBoton, _lesson_english, _english, ENGLISH, _word_english);
            Up(contextBoton, _lesson_deutsch, _deutsch, DEUTSCH, _word_deutsch);
            Up(contextBoton, _lesson_italiano, _italiano, ITALIANO, _word_italiano);
            Up(contextBoton, _lesson_francais, _francais, FRANCAIS, _word_francais);
            Up(contextBoton, _lesson_espanol, _espanol, ESPANOL, _word_espanol);
        }

        private void SetLesson(FraseModel fraseModel, string language)
        {
            try
            {
                if (language == ENGLISH) _english = fraseModel;
                if (language == DEUTSCH) _deutsch = fraseModel;
                if (language == ITALIANO) _italiano = fraseModel;
                if (language == FRANCAIS) _francais = fraseModel;
                if (language == ESPANOL) _espanol = fraseModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetPhrase(List<WordModel> phrase, string language)
        {
            try
            {
                if (language == ENGLISH) _word_english = phrase;
                if (language == DEUTSCH) _word_deutsch = phrase;
                if (language == ITALIANO) _word_italiano = phrase;
                if (language == FRANCAIS) _word_francais = phrase;
                if (language == ESPANOL) _word_espanol = phrase;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int SelectButton(string language, int option)
        {
            try
            {
                if ((language == ENGLISH) && (option == 1)) return Resource.Id.txt_viw_box_1_1;
                if ((language == ENGLISH) && (option == 2)) return Resource.Id.txt_viw_box_1_2;
                if ((language == ENGLISH) && (option == 3)) return Resource.Id.txt_viw_box_1_3;
                if ((language == DEUTSCH) && (option == 1)) return Resource.Id.txt_viw_box_2_1;
                if ((language == DEUTSCH) && (option == 2)) return Resource.Id.txt_viw_box_2_2;
                if ((language == DEUTSCH) && (option == 3)) return Resource.Id.txt_viw_box_2_3;
                if ((language == ITALIANO) && (option == 1)) return Resource.Id.txt_viw_box_3_1;
                if ((language == ITALIANO) && (option == 2)) return Resource.Id.txt_viw_box_3_2;
                if ((language == ITALIANO) && (option == 3)) return Resource.Id.txt_viw_box_3_3;
                if ((language == FRANCAIS) && (option == 1)) return Resource.Id.txt_viw_box_4_1;
                if ((language == FRANCAIS) && (option == 2)) return Resource.Id.txt_viw_box_4_2;
                if ((language == FRANCAIS) && (option == 3)) return Resource.Id.txt_viw_box_4_3;
                if ((language == ESPANOL) && (option == 1)) return Resource.Id.txt_viw_box_5_1;
                if ((language == ESPANOL) && (option == 2)) return Resource.Id.txt_viw_box_5_2;
                if ((language == ESPANOL) && (option == 3)) return Resource.Id.txt_viw_box_5_3;
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        void Next(Context context, List<FraseModel> book, FraseModel lesson, string language)
        {
            if (!pause1)
            {
                int value = book.IndexOf(lesson) + 1;
                if (value == book.Count) value = book.IndexOf(lesson);
                if (book.Count != 0)
                {
                    //---
                    lesson = book[value];
                    SetLesson(lesson, language);
                    //---
                    List<WordModel> word = _mainViewModel.GetNext(language, lesson, book);
                    //---
                    SetPhrase(word, language);
                    //---
                    word.ForEach(index =>
                    {
                        if ((index.kind == VAR_PRONOUN) && (index.sentense == VAR_SUBJECT))
                        {
                            TextView text_pronoun = (TextView)((Activity)context).FindViewById(SelectButton(language, 1));
                            text_pronoun.Text = index.term;
                        }
                        if (index.kind == VAR_VERB)
                        {
                            TextView text_verb = (TextView)((Activity)context).FindViewById(SelectButton(language, 2));
                            text_verb.Text = index.term;
                        }
                        if ((index.kind == VAR_NOUN) && (index.sentense == VAR_PREDICATE))
                        {
                            TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                            text_noun.Text = index.term;
                        }
                        if (word.Count == 2)
                        {
                            TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                            text_noun.Text = "";
                        }
                    });
                }
            }
        }

        void Previous(Context context, List<FraseModel> book, FraseModel lesson, string language)
        {
            if (!pause1)
            {
                int value = book.IndexOf(lesson) - 1;
                if (value == -1) value = 0;
                if (book.Count != 0)
                {
                    //---
                    lesson = book[value];
                    SetLesson(lesson, language);
                    //---
                    List<WordModel> word = _mainViewModel.GetNext(language, lesson, book);
                    word.ForEach(index =>
                    {
                        if ((index.kind == VAR_PRONOUN) && (index.sentense == VAR_SUBJECT))
                        {
                            TextView text_pronoun = (TextView)((Activity)context).FindViewById(SelectButton(language, 1));
                            text_pronoun.Text = index.term;
                        }
                        if (index.kind == VAR_VERB)
                        {
                            TextView text_verb = (TextView)((Activity)context).FindViewById(SelectButton(language, 2));
                            text_verb.Text = index.term;
                        }
                        if ((index.kind == VAR_NOUN) && (index.sentense == VAR_PREDICATE))
                        {
                            TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                            text_noun.Text = index.term;
                        }
                        if (word.Count == 2)
                        {
                            TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                            text_noun.Text = "";
                        }
                    });
                }
            }
        }

        void Down(Context context, List<FraseModel> book, FraseModel lesson, string language, List<WordModel> word_model)
        {
            if (
                ((pause1) && (language == ENGLISH)) ||
                ((pause2) && (language == DEUTSCH)) ||
                ((pause3) && (language == ITALIANO)) ||
                ((pause4) && (language == FRANCAIS)) ||
                ((pause5) && (language == ESPANOL))
                )
            {
                //---
                List<WordModel> word = _mainViewModel.GetDown(language, word_model, true);
                //---
                SetPhrase(word, language);
                //---
                word.ForEach(index =>
                {
                    if ((index.kind == VAR_PRONOUN) && (index.sentense == VAR_SUBJECT))
                    {
                        TextView text_pronoun = (TextView)((Activity)context).FindViewById(SelectButton(language, 1));
                        text_pronoun.Text = index.term;
                    }
                    if (index.kind == VAR_VERB)
                    {
                        TextView text_verb = (TextView)((Activity)context).FindViewById(SelectButton(language, 2));
                        text_verb.Text = index.term;
                    }
                    if ((index.kind == VAR_NOUN) && (index.sentense == VAR_PREDICATE))
                    {
                        TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                        text_noun.Text = index.term;
                    }
                    if (word.Count == 2)
                    {
                        TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                        text_noun.Text = "";
                    }
                });
                //int value_verb = _italiano.conteudo.verbo.Distinct().ToList().IndexOf(_italiano_verb) + 1;
                //if (value_verb == -1) value_verb = 0;
                //if (_italiano.conteudo.verbo.Count != 0)
            }
        }

        void Up(Context context, List<FraseModel> book, FraseModel lesson, string language, List<WordModel> word_model)
        {
            if (
                ((pause1) && (language == ENGLISH)) ||
                ((pause2) && (language == DEUTSCH)) ||
                ((pause3) && (language == ITALIANO)) ||
                ((pause4) && (language == FRANCAIS)) ||
                ((pause5) && (language == ESPANOL))
                )
            {
                {
                    //---
                    List<WordModel> word = _mainViewModel.GetDown(language, word_model, false);
                    //---
                    SetPhrase(word, language);
                    //---
                    word.ForEach(index =>
                    {
                        if ((index.kind == VAR_PRONOUN) && (index.sentense == VAR_SUBJECT))
                        {
                            TextView text_pronoun = (TextView)((Activity)context).FindViewById(SelectButton(language, 1));
                            text_pronoun.Text = index.term;
                        }
                        if (index.kind == VAR_VERB)
                        {
                            TextView text_verb = (TextView)((Activity)context).FindViewById(SelectButton(language, 2));
                            text_verb.Text = index.term;
                        }
                        if ((index.kind == VAR_NOUN) && (index.sentense == VAR_PREDICATE))
                        {
                            TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                            text_noun.Text = index.term;
                        }
                        if (word.Count == 2)
                        {
                            TextView text_noun = (TextView)((Activity)context).FindViewById(SelectButton(language, 3));
                            text_noun.Text = "";
                        }
                    });
                    //int value_verb = _italiano.conteudo.verbo.Distinct().ToList().IndexOf(_italiano_verb) - 1;
                    //if (value_verb == -1) value_verb = 0;
                    //if (_italiano.conteudo.verbo.Count != 0)
                }
            }
        }
    }
}