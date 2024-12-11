import axios from "axios";

export const getPlayers = async () => {
    const response = await axios.get("http://localhost:5000/player");
    return response.data;
};