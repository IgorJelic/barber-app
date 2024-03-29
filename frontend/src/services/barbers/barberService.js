import axios from '../api/axiosConfig.js';

const BARBERS_URL = process.env.REACT_APP_BARBERS_URL

export const barberService = {
    getAllBarbers: async (filter) => {
        try {
            const response = await axios.get(BARBERS_URL,{params: filter});
            return response.data;
        } catch (error) {
            console.log(error);
        }
    },

    getBarberById: async (barberId) => {
        try {
            const response = await axios.get(`${BARBERS_URL}/${barberId}`);
            return response.data;
        } catch (error) {
            console.log(error);
        }
    },
}