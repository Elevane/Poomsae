import { useRecoilState } from "recoil"
import { ApiResult } from "../../Models/ApiResult"
import api from "../Api/Api"
import { ParentEntity } from "../../Models/SportsModels"
import userSportsState from "../../state/userSportsState"


const useSportService = () => {
    const [, setSports] = useRecoilState(userSportsState)

    const apiBaseRoute = `${import.meta.env.VITE_APP_API_URL}/api`

    async function getSports(id: number) {
        const response: ApiResult<ParentEntity[]> = await api.get<ParentEntity[]>(`${apiBaseRoute}/sports/${id}`, null)
        if (response?.result != null)
            setSports(response.result)
    }



    return { getSports }
}
export default useSportService