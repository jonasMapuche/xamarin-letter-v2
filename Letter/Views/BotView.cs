using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Letter.Adapters;
using Letter.Models;
using Letter.ViewsModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Views
{
    public class BotView
    {
        private Context context;
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        BotAdapter adapter;
        List<MessageModel> chatMessage;

        public BotView(Context context)
        {
            this.context = context;
            ImageButton imageButton;
            imageButton = (ImageButton)((Activity)context).FindViewById(Resource.Id.img_but_send);
            imageButton.Click += async (sender, e) => 
            {
                EditText editSend = (EditText)((Activity)this.context).FindViewById(Resource.Id.edt_txt_input);
                MessageModel message = new MessageModel();
                message.text = editSend.Text;
                message.sender = adapter.VIEW_TYPE_SEND;

                BotViewModel botViewModel = new BotViewModel();

                MessageModel result = await botViewModel.Post(message);

                MessageModel response = new MessageModel();
                response.sender = 1;
                response.text = result.text;
                chatMessage.Add(response);
                adapter.NotifyDataSetChanged();
            };

            recyclerView = (RecyclerView)((Activity)context).FindViewById(Resource.Id.rcy_view_bot);
            layoutManager = new LinearLayoutManager((Activity)context);
            recyclerView.SetLayoutManager(layoutManager);

            chatMessage = new List<MessageModel>();
            MessageModel message = new MessageModel();
            message.sender = 2;
            message.text = "Hi!";
            chatMessage.Add(message);
            message = new MessageModel();
            message.sender = 2;
            message.text = "What can I do?";
            chatMessage.Add(message);
            adapter = new BotAdapter(chatMessage);
            recyclerView.SetAdapter(adapter);

        }

    }
}