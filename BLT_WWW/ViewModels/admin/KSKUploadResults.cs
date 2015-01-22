﻿using BLT.Core.Import;
using BLT.Core.Models;
using BLT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BLT.WWW.Serialization;
using System.Text;
namespace BLT.WWW.ViewModels
{
    public class KSKUploadResults
    {
        public string EncodedImportData
        {
            get
            {
                
                
                byte[] bytes = System.Text.Encoding.UTF32.GetBytes(ImportData.ToJson());
                return Convert.ToBase64String(bytes);
                
            }
        }
        public KSKListImportResult ImportData { get; set; }
        public void CheckUsersAgainstDatabase()
        {
            using (BLTContext context = new BLTContext())
            {
                var classes = context.Classes.ToList();
                foreach (ImportUser user in ImportData.Users)
                {
                    var namesplit = user.Name.Split('-');
                    string firstName = namesplit[0];
                    string serverName = namesplit[1];
                    if (context.Characters.Any(c => firstName == c.Name && serverName == c.ServerName))
                    {
                        user.IsInDatabase = true;
                    }
                }
            }
        }

        public bool HasNewCharacters
        {
            get
            {
                if (ImportData.Users == null || ImportData.Users.Count == 0)
                    return false;

                return ImportData.Users.Any(c => !c.IsInDatabase);
            }
        }
    }
}