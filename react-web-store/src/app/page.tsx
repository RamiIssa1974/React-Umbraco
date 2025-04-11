
import SalesCarousel from "./components/SalesCarousel";
import SalesList from "./components/SalesList";
import styles from "./page.module.css";

export default function Home() {
    return (
        <div className={styles.page}>
            <h1>Welcome to the Store</h1>
            <SalesCarousel />            
        </div>
    );
}
