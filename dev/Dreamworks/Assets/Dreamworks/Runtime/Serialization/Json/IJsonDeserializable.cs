﻿/**Copyright 2016 - 2020, Dream Machine Game Studio. All Right Reserved.*/

namespace DreamMachineGameStudio.Dreamworks.Serialization.Json
{
    public interface IJsonDeserializable
    {
        void FromJson(FJsonObject jsonObject);
    }
}