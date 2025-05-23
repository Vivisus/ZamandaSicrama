import json
from google.cloud import firestore


SERVICE_ACCOUNT_KEY_PATH = "zamandasicrama-firebase-adminsdk-fbsvc-2653d2f06e.json"


db = firestore.Client.from_service_account_json(SERVICE_ACCOUNT_KEY_PATH)


JSON_PATH = "senaryo.json"


def upload_npcs(json_path):
    with open(json_path, "r", encoding="utf-8") as f:
        data = json.load(f)

    npcs = data.get("npcs", [])
    for npc in npcs:
        npc_id = npc.get("npcName", "unknown").lower()
        doc_ref = db.collection("npcs").document(npc_id)


        doc_ref.set(npc)
        print(f"{npc_id} başarıyla yüklendi.")

if __name__ == "__main__":
    upload_npcs(JSON_PATH)
