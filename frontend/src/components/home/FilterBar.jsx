import { useContext, useState } from 'react'
import { FilterContext } from '../../contexts/FilterContext'
import styles from './Home.module.css'
import { Gender } from '../../utils/fetchingFilters/genderEnum';

export default function FilterBar({}){
    const [maleBtnActive, setMaleBtnActive] = useState(false);
    const [femaleBtnActive, setFemaleBtnActive] = useState(false);
    const setFilter = useContext(FilterContext);
    let timeoutId;

    const handleGender = (gender) => {
        switch (gender) {
            case Gender.Male:
                if (maleBtnActive) resetGender();
                else setFilter(prevFilter => ({
                    ...prevFilter,
                    gender: Gender.Male
                }))

                setMaleBtnActive(!maleBtnActive);
                setFemaleBtnActive(false);
                break;
            case Gender.Female:
                if (femaleBtnActive) resetGender();
                else setFilter(prevFilter => ({
                    ...prevFilter,
                    gender: Gender.Female
                }))

                setFemaleBtnActive(!femaleBtnActive);
                setMaleBtnActive(false);
                break;
            default:
                break;
        }
    }

    const resetGender = () => {
        setFilter(prevFilter => ({
            ...prevFilter,
            gender: undefined
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
                <button>Popularity</button>
                <button>Rating</button>
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