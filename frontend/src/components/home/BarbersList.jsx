import Pagination from "../common/Pagination";
import BarberCard from "./BarberCard"
import styles from './Home.module.css'

export default function BarberList({data}){
    // const barbers = data.barbers;
    // const activePage = data.pageNumber;
    // const pageCount = data.pageCount;

    const barbers = [
        {
          id: 1,
          username: "JohnDoe",
          gender: "Male",
          rating: 4.5,
          appointmentsCount: 20
        },
        {
          id: 2,
          username: "JaneSmith",
          gender: "Female",
          rating: 4.2,
          appointmentsCount: 18
        },
        {
          id: 3,
          username: "MikeJohnson",
          gender: "Male",
          rating: 4.7,
          appointmentsCount: 25
        },
        {
          id: 4,
          username: "EmilyDavis",
          gender: "Female",
          rating: 4.0,
          appointmentsCount: 15
        }
      ];
    const activePage = 2;
    const pageCount = 4;

    const content = barbers.map(b => <BarberCard key={b.id} barber={b}/>);

    return(
        <>
            <div className={styles.container}>
                <h1 className={styles.listTitle}>Looking for a fresh look?</h1>
                <h3 className={styles.listSubtitle}>These guys can help:</h3>
                <div className={styles.content}>
                    {content}
                </div>
                <Pagination activePage={activePage} pageCount={pageCount} />
            </div>
        </>
    )
}