import { useEffect } from "react"
import { barberService } from "../services/barbers/barberService"
import { useState } from "react"
import { BarberFilterObject } from "../utils/fetchingFilters/barbersFilter";
import BarberList from "../components/home/BarbersList";
import {Gender} from '../utils/fetchingFilters/genderEnum';


export default function HomePage(){
    const [data, setData] = useState({
        barbers: [],
        pageNumber: 1,
        pagesCount: 0
    });
    let filter = new BarberFilterObject(
        {
            sortByPopularity: undefined,
            sortByRating: undefined,
            pageNumber:1,
            pageSize:4,
            gender: Gender.Male
        });


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
    }, [])

    return (
        <>
            <BarberList data={data}/>
        </>
    )
}

