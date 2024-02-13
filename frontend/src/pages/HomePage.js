import { useEffect } from "react"
import { barberService } from "../services/barbers/barberService"
import { useState } from "react"
import { BarberFilterObject } from "../utils/fetchingFilters/barbersFilter";
import BarberList from "../components/home/BarbersList";
import { FilterContext } from "../contexts/FilterContext";

export default function HomePage(){
    const [data, setData] = useState({
        barbers: [],
        pageNumber: 1,
        pagesCount: 0
    });

    const [filter, setFilter] = useState(new BarberFilterObject({
        username: undefined,
        sortByPopularity: undefined,
        sortByRating: undefined,
        pageNumber:1,
        pageSize: window.innerWidth < 1490 ? 4 : 6,
        gender: undefined
    }))

    useEffect(() => {
        barberService.getAllBarbers(filter)
            .then(
                result => result && setData(result)
            )
            .catch(
                error => {
                    console.error(error)
                    return { barbers: [], pageNumber: 1, pagesCount: 0 };
                }
            )
    }, [filter])

    return (
        <FilterContext.Provider value={setFilter}>
            <BarberList data={data}/>
        </FilterContext.Provider>
    )

    
}

