from symspellcompound.symspellcompound import SySpellCompound

ssc = SySpellCompound()
print(ssc.load_dictionary("fr_full.txt", language="fr", term_index=0, count_index=1))
print(ssc.dictionary.get("frprobleme"))
# print(ssc.create_dictionary("model_fr.txt", "fr"))

print(ssc.lookup_compound(input_string="le problm avc cete solutin", language="fr", edit_distance_max=3))
