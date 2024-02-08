import axios from '../api/axiosConfig.js';

const BARBERS_URL = '/barbers'

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
            const response = await axios.get(BARBERS_URL,{params: {id: barberId}});
            return response.data;
        } catch (error) {
            console.log(error);
        }
    },

    calculateRating: (appointments) => {
        return 3.5;

        let ratedAppointments = appointments.filter(a => a.rating !== null);

        if (ratedAppointments.length === 0) return 0;

        const totalRating = ratedAppointments.reduce((sum, appointment) => sum + appointment.rating, 0);
        return totalRating / ratedAppointments.length;
    }
}