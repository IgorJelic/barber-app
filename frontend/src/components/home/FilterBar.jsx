import styles from './Home.module.css'

export default function FilterBar({}){

    return(
        <>
            <div className={styles.filterRow}>
                <h3>Filters:</h3>
            </div>
            <div className={styles.filterRow}>
                <label htmlFor="search">🔎: </label>
                <input type="text" name="search" id="search" placeholder="Barber name"/>
            </div>
            <div className={styles.filterRow}>
                <b>Sort:</b>
                <button>Popularity</button>
                <button>Rating</button>
            </div>
            <div className={styles.filterRow}>
                <b>Gender:</b> 
                <button className={styles.genderBtn}>M</button>
                <button className={styles.genderBtn}>F</button>
            </div>
        </>
    )
}