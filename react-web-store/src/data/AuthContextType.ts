import { User } from "./User";
export interface AuthContextType {
    loading: boolean;
    isLoggedIn: boolean;
    user: User | null;
    login: (username: string, password: string) => Promise<User>;
    logout: () => void;
}