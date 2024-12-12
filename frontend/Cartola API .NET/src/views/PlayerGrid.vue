<template>
    <div>
        <h1>Player List</h1>
        <table>
            <thead>
                <tr>
                    <th>Photo</th>
                    <th>Name</th>
                    <th>Team</th>
                    <th>Position</th>
                    <th>Games Played</th>
                    <th>Points</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="player in players" :key="player.id">
                    <td><img :src="player.photoUrl" alt="Player Photo" width="50"></td>
                    <td>{{ player.name }}</td>
                    <td>{{ player.team }}</td>
                    <td>{{ player.position }}</td>
                    <td>{{ player.gamesPlayed }}</td>
                    <td>{{ player.currentPoints }}</td>
                    <td>{{ player.price }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import { getPlayers } from "../api/players";

export default {
    data() {
        return {
            players: [],
        };
    },
    async created() {
        this.players = await getPlayers();
    },
};
</script>
