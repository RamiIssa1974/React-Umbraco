 
import Link from "next/link";
import "./globals.css"; // keep this for global styles
import "../styles/layout.css";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

export const metadata = {
    title: "React Web Store",
    description: "A simple product store with Umbraco backend",
};

export default function RootLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return (
        <html lang="en">
            <body>
                <header className="header">
                    <Link href="/">Home</Link>
                    <Link href="/products">Products</Link>
                </header>
                <main style={{ padding: "1rem" }}>{children}</main>
            </body>
        </html>
    );
}
