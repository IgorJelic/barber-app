export const formatDate = (date) => {
    const options = { 
        month: 'short', 
        day: 'numeric',
        hour12: false,
        hour: 'numeric',
        minute: '2-digit' 
    };
    return new Date(date).toLocaleDateString(undefined, options);
};