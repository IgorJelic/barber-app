import styles from './Common.module.css'

export default function StarRating({rating}){

    const getMaxRating = () => {
        if (rating > 4.5) return 5;
        else if (rating > 3.5) return 4;
        else if (rating > 2.5) return 3;
        else if (rating > 1.5) return 2;
        else if (rating > 0.5) return 1;
        else return 0;
    }

    const maxRating = getMaxRating(rating);
    const stars = [1, 2, 3, 4, 5].map((index) => (
        <div key={index} className={`${styles.star} ${index <= maxRating ? styles.filled : ''}`}>
            &#9733;
        </div>
    ))

    return(
        <div className={styles.starRating}>
            Rating: {stars}
        </div>
    )
}