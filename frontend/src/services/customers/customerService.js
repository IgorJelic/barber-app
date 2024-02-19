import axios from '../api/axiosConfig.js';

const CUSTOMERS_URL = process.env.REACT_APP_CUSTOMERS_URL

export const customerService = {

    makeAppointment: async(appointment) => {
        try {
            const response = await axios.post(`${CUSTOMERS_URL}/appointment`, {appointment: appointment});
            return response.data;
        }
        catch (error) {
            console.log(error);
        }
    }
}