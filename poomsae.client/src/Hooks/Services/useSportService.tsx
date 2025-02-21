import api from "../Api/Api"
import { ParentEntity } from "../../Models/SportsModels"
import { useRecoilState } from "recoil"
import { authState } from "../../state/auth"
import ContentType from "../Api/ContentType"

const useSportService = () => {

    const apiBaseRoute = `${import.meta.env.VITE_APP_API_URL}/api`
    const [auth,] = useRecoilState(authState)
    async function fetchSports() {
        const res = await api.get<ParentEntity[]>(`${apiBaseRoute}/usersports`, null, ContentType.json, auth.token)
        if (res.failure || !res.result) {
            throw new Error("Erreur lors de la récupération des sports.");
        }
        return res.result
    }

    return { fetchSports }
}
export default useSportService