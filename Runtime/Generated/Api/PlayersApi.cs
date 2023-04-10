using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Object = System.Object;

namespace OpenfortSdk
{
    public partial class PlayersApi
    {
        ApiClient apiClient;

        public PlayersApi(ApiClient apiClient)
        {
            this.apiClient = apiClient;
        }


        /// <summary>
        /// Get players
        /// </summary>
        ///
        /// <remarks>
        /// Returns all players for the authenticated game as an array of player objects.
        /// </remarks>
        /// <returns>List<PublicPlayer></returns>
        public async UniTask<GetPlayersData200Response> GetPlayers(CancellationToken token = default, Dictionary<string, string> headers = null)
        {

            return await apiClient.Get<GetPlayersData200Response>($"/v1/players", headers: headers);

        }


    }
}
