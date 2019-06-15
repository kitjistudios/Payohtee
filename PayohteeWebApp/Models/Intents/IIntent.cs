using System.Collections.Generic;

namespace PayohteeWebApp.Models.Intents
{
    interface IIntent
    {
        /// <summary>
        /// My contract should create a new intent object 
        /// </summary>
        /// <value>
        /// this should create a new intent
        /// </value>
        void CreateIntent(Intent Intent);

        /// <summary>
        /// My contract should create a new list of intent object 
        /// </summary>
        /// <value>
        /// this should create a new list of intent
        /// </value>
        void CreateListIntent(List<Intent> IntentList);

        /// <summary>
        /// My contract should get an intent object 
        /// </summary>
        /// <value>
        /// this should get an intent
        /// </value>
        List<Intent> GetIntent(int id);
    }
}
