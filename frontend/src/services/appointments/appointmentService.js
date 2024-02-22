import axios from '../api/axiosConfig.js';

const APPOINTMENTS_URL = process.env.REACT_APP_APPOINTMENTS_URL

export const appointmentService = {

    makeAppointment: async(appointment) => {
        try {
            const response = await axios.post(APPOINTMENTS_URL, appointment);
            return response.data;
        }
        catch (error) {
            console.log(error);
        }
    }
}