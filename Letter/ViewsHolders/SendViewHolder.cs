using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Letter.ViewsHolders
{
    public class SendViewHolder : RecyclerView.ViewHolder
    {
        public TextView send { get; private set; }
        
        public SendViewHolder(View itemView) : base(itemView)
        {
            send = (TextView)itemView.FindViewById(Resource.Id.txt_viw_send);
        }

        public void SendData(View itemView)
        {
            send = (TextView)itemView.FindViewById(Resource.Id.txt_viw_send);
        }
    }
}