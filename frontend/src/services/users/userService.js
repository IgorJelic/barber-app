import axios from '../api/axiosConfig.js'

const USERS_URL = process.env.REACT_APP_USERS_URL

export const userService = {
    login: async (user) => {
        try {
            const response = await axios.post(`${USERS_URL}/login`, user);
            return response.data;
        }
        catch (error){
            console.log(error);
        }
    }
}