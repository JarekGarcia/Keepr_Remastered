import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService{
    async GetKeeps(){
        const res = await api.get("api/keeps");
        AppState.keeps = res.data.map(keep => new Keep(keep));
        logger.log("this is the keeps in the appstate", AppState.keeps);
    }
}

export const keepsService = new KeepsService