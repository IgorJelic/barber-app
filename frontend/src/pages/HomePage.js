import { createContext, useEffect } from "react"
import { barberService } from "../services/barbers/barberService"
import { useState } from "react"
import { BarberFilterObject } from "../utils/fetchingFilters/barbersFilter";
import BarberList from "../components/home/BarbersList";
import {Gender} from '../utils/fetchingFilters/genderEnum';
import { PaginationContext } from "../contexts/PaginationContext";

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
        pageSize:4,
        gender: undefined
    }))

    // Check viewport width and put default pageSize to 6 or 4 accordingly

    const updatePageNumber = (newPageNumber) => {
        setFilter(prevFilter => ({
            ...prevFilter,
            pageNumber: newPageNumber
        }));
    };


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
        <PaginationContext.Provider value={updatePageNumber}>
            <BarberList data={data}/>
        </PaginationContext.Provider>
    )
}

