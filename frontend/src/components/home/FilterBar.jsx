import { useContext, useState } from 'react'
import { FilterContext } from '../../contexts/FilterContext'
import styles from './Home.module.css'
import { Gender } from '../../utils/fetchingFilters/genderEnum';
import { Sorting } from '../../utils/fetchingFilters/sortingEnum';

export default function FilterBar(){
    const [maleBtnActive, setMaleBtnActive] = useState(false);
    const [femaleBtnActive, setFemaleBtnActive] = useState(false);
    const [popSorting, setPopSorting] = useState(Sorting.None);
    const [rankSorting, setRankSorting] = useState(Sorting.None);

    const setFilter = useContext(FilterContext);
    let timeoutId;

    const handleSorting = (sort) => {
        switch (sort) {
            case 'popularity':
                setPopularitySort((popSorting + 1) % 3);
            break;
            case 'rank':
                setRankSort((rankSorting + 1) % 3);
            break;
            default:
                break;
        }
    }

    const setRankSort = (r) => {
        setFilter(prevFilter => ({
            ...prevFilter,
            sortByRating: r
        }))
        setRankSorting(r);
    }

    const setPopularitySort = (p) => {
        setFilter(prevFilter => ({
            ...prevFilter,
            sortByPopularity: p
        }))
        setPopSorting(p);
    }

    const handleGender = (gender) => {
        switch (gender) {
            case Gender.Male:
                if (maleBtnActive) setGender(undefined);
                else setGender(Gender.Male);

                setMaleBtnActive(!maleBtnActive);
                setFemaleBtnActive(false);
                break;
            case Gender.Female:
                if (femaleBtnActive) setGender(undefined);
                else setGender(Gender.Female);

                setFemaleBtnActive(!femaleBtnActive);
                setMaleBtnActive(false);
                break;
            default:
                break;
        }
    }

    const setGender = (g) => {
        setFilter(prevFilter => ({
            ...prevFilter,
            gender: g
        }))
    }

    const handleInput = (e) => {
        clearTimeout(timeoutId);

        const query = e.target.value;
        
        timeoutId = setTimeout(() => {
            setFilter(prevFilter => ({
                ...prevFilter,
                username: query
            }))
        }, 400);
    }

    return(
        <>
            <div className={styles.filterRow}>
                <label htmlFor="search">🔎: </label>
                <input className={styles.searchInput} 
                    type="text" name="search" id="search" 
                    placeholder="Barber name"
                    onChange={handleInput}
                />
            </div>
            <div className={styles.filterRow}>
                <b>Sort:</b>
                <button
                    onClick={() => handleSorting('popularity')}
                    className={`${styles.sortBtn} ${popSorting === Sorting.Descending ? styles.desc : 
                                                    popSorting === Sorting.Ascending ? styles.asc :
                                                    ''}`}>
                        Pop.
                </button>
                <button
                    onClick={() => handleSorting('rank')}
                    className={`${styles.sortBtn} ${rankSorting === Sorting.Descending ? styles.desc : 
                                                    rankSorting === Sorting.Ascending ? styles.asc :
                                                    ''}`}>
                        Rank
                </button>
            </div>
            <div className={styles.filterRow}>
                <b>Gender:</b> 
                <button 
                    onClick={() => handleGender(Gender.Male)} 
                    className={`${styles.genderBtn} ${maleBtnActive ? styles.active : ''}`}>M</button>
                <button 
                    onClick={() => handleGender(Gender.Female)} 
                    className={`${styles.genderBtn} ${femaleBtnActive ? styles.active : ''}`}>F</button>
            </div>
        </>
    )
}