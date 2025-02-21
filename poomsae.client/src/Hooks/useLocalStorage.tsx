import { AppUser } from "../Models/AppModels"

const useLocalStorage = () => {
    const GetUser = (): AppUser => {
        if (!import.meta.env.VITE_APP_COOKIE_KEY) return { isAuthenticated: false }
        const locals = localStorage.getItem(import.meta.env.VITE_APP_COOKIE_KEY)
        if (locals)
            return JSON.parse(locals)
        else return { isAuthenticated: false }
    }

    const SetUser = (item: object) => {
        if (import.meta.env.VITE_APP_COOKIE_KEY)
            localStorage.setItem(import.meta.env.VITE_APP_COOKIE_KEY, JSON.stringify(item))
    }

    const removeUser = () => {
        if (import.meta.env.VITE_APP_COOKIE_KEY)
            localStorage.removeItem(import.meta.env.VITE_APP_COOKIE_KEY)
    }
    return { GetUser, SetUser, removeUser }
}

export default useLocalStorage