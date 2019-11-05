using HugoLandEditeur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLandEditeur.ViewModels
{
    public class GestionChatMessage
    {
        // liste des erreurs de connexion
        public List<string> LstErreursChatMessages { get; set; } = new List<string>();

        // Update chatbox editor if there is new post in database
        public List<string> UpdateEditorChatBox(int lastId)
        {
            List<ChatMessage> lstChats = new List<ChatMessage>();
            List<string> lstMessages = new List<string>();
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    if (contexte.ChatMessages.Any(x => x.MessageID > lastId))
                    {

                        lstChats = contexte.ChatMessages.Where(x => x.ContextPost == "Editor").OrderByDescending(x => x.MessageID).Take(50).ToList();
                        foreach (ChatMessage chat in lstChats)
                        {
                            lstMessages.Add(chat.DatePost + "\r\n" + chat.CompteJoueur.NomJoueur + " say : \r\n" + chat.MessageText + "\r\n\r\n");
                        }

                        return lstMessages;
                    }
                    else
                    {
                        return lstMessages;
                    }
                }
            }
            catch (Exception ex)
            {
                LstErreursChatMessages.Add(ex.Message);
                lstMessages.Add("??? ERROR ???");
                return lstMessages;
            }
        }

        // Chatbox post method Editor chatbox
        public void PostOnChatEditor(int Id, string Message)
        {
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    if (contexte.CompteJoueurs.Any(x => x.Id == Id) && Message != "")
                    {
                        ChatMessage chatMessage = new ChatMessage
                        {
                            CompteJoueurId = Id,
                            MessageText = Message,
                            DatePost = DateTime.Now,
                            ContextPost = Constantes.ContextChat.Editor.ToString()
                        };
                        contexte.ChatMessages.Add(chatMessage);
                        contexte.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                LstErreursChatMessages.Add(ex.Message);
            }
        }

        //Get the last post id to determine the neccesity of refreshing chatbox.
        public int GetLastEditorPostId()
        {
            int lastId = 0;
            try
            {
                using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
                {
                    lastId = (from chat in contexte.ChatMessages orderby chat.MessageID descending select chat.MessageID).First();
                    return lastId;
                }
            }
            catch (Exception ex)
            {
                LstErreursChatMessages.Add(ex.Message);
                return lastId;
            }
        }
    }
}
