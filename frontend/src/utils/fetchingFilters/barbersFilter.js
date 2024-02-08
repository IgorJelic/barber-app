class BarberFilterObject{
    constructor({
        sortByPopularity = undefined,
        sortByRating = undefined,
        pageSize = undefined,
        pageNumber = undefined,
        gender = undefined
    } = {}) 
    {
        this.sortByPopularity = sortByPopularity;
        this.sortByRating = sortByRating;
        this.pageSize = pageSize;
        this.pageNumber = pageNumber;
        this.gender = gender;
    }
}

export {BarberFilterObject};