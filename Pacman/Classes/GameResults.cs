using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Pacman
{
    class GameResults
    {
        public string incorectNickname { get; set; }
        public string enteredNickname { get; set; }

        public List<Result> resultsList { get; set; }

        public GameResults()
        {
            incorectNickname = string.Empty;
            enteredNickname = string.Empty;
            resultsList = new List<Result>(LoadResults());
        }
        ~GameResults() { }
        
        public void SetResultsValue(Result item) { resultsList.Add(item); }

        private List<Result> LoadResults()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream(Resource.ResultsPath, FileMode.OpenOrCreate))
                {
                    return (List<Result>)bf.Deserialize(fs);
                }
            }
            catch { };
            return new List<Result>();
        }

        public List<Result> SearchResults()
        {
            if (string.IsNullOrEmpty(enteredNickname))
                return new List<Result>();
            else
            {
                List<Result> selected = new List<Result>();

                foreach (Result item in resultsList)
                    if (item.nickname.Equals(enteredNickname))
                        selected.Add(item);

                if(selected.Count.Equals(0))
                {
                    incorectNickname = "User \"" + enteredNickname + "\" not found!";
                    return new List<Result>();
                }    
                return selected;
            }
        }

        public List<Result> DeleteResults(List<Result> delIndexList)
        {
            foreach (Result item in delIndexList)
                if (item.nickname.Equals(Methods.GetCurrentUser().login) 
                    && !GetEqualsIndex(resultsList, item).Equals(-1))
                        resultsList.RemoveAt(GetEqualsIndex(resultsList, item));
            
            Methods.Save(Resource.ResultsPath, FileMode.Create, resultsList);
            return resultsList;
        }

        private int GetEqualsIndex(List<Result> resultsList, Result result)
        {
            foreach (Result item in resultsList)
                if (item.nickname.Equals(result.nickname)
                    && item.score.Equals(result.score)
                    && item.attempt.Equals(result.attempt))
                    return resultsList.IndexOf(item);
            return -1;
        }
    }
}
