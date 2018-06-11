select AI.AppId,AI.Fname,AI.Lname,CI.Iss_date,CI.Exp_date,US.mohSig,FHC.HandlerName
from ApplicantsInfo AI,Card_Info CI, Users US, FoodHandlersCategories FHC,SignOff where
AI.AppID=CI.AppID and CI.TrainID=SignOff.TrainID and SignOff.MOH_ID=US.UserID and CI.HandlerID=FHC.HandlerID
and CI.trainID ='14' and SignOff.signed='1' and SignOff.InBatch='0'
