export interface MenuItem {
    name: string;
    href?: string;
    onClick?: () => void;
    submenu?: {
        id: number;
        name: string;
        href: string;
    }[];
}
