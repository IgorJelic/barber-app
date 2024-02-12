import Pagination from "../common/Pagination";
import BarberCard from "./BarberCard"
import FilterBar from "./FilterBar";
import styles from './Home.module.css'

export default function BarberList({data}){
    const barbers = data.barbers;
    const activePage = data.pageNumber;
    const pageCount = data.pages;

    const content = barbers.map(b => <BarberCard key={b.id} barber={b}/>);

    return(
        <>
          <div className={styles.contentWrap}>
            <div className={styles.container}>
              <h1 className={styles.listTitle}>Looking for a fresh look?</h1>
              <h3 className={styles.listSubtitle}>These guys can help:</h3>
              <div className={styles.content}>
                  {content}
              </div>
              <Pagination activePage={activePage} pageCount={pageCount} />
            </div>
            <div className={styles.filterBar}>
              <FilterBar/>
            </div>
          </div>
        </>
    )
}