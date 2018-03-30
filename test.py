import os
from symspellcompound.symspellcompound import SySpellCompound

ssc = SySpellCompound()

print('Test 1')
print(ssc.create_dictionary(os.path.abspath("lists/bonjour.txt"), "fr"))
# This works fine but breaks with the string "bonjur bonjouir", seems to be something with insertions
print(ssc.lookup_compound(input_string="bonjur bonjour", language="fr", edit_distance_max=2))
print(ssc.dictionary.get("frbonjour"))
print()

print('Test 2')
# Fixed!
print(ssc.load_dictionary("lists/bonjour.1.txt", language="fr", term_index=0, count_index=1))
print(ssc.lookup_compound(input_string="bonjuor", language="fr", edit_distance_max=2))
print()

print('Test 3')
# this works file with just "bonjur" or "bonjur hllo", but can't deal with a substitution in "hallo"
# with "bonjur hello" it gives the frequency of hello, even though it fixed bonjur
# what about the frequency?
print(ssc.load_dictionary("lists/bonjour.2.txt", language="fr", term_index=0, count_index=1))
print(ssc.lookup_compound(input_string="bonjur hallo", language="fr", edit_distance_max=2))
print()

print('Test 4')
# breaks with "བཀྲ་ཤས་་", breaks with "བཀྲ་ཤིན་", doesn't recognize "བཀྲ་ཤེས་", or "སཀྲ་ཤིས་"
print(ssc.load_dictionary("lists/tib.txt", language="fr", term_index=0, count_index=1))
print(ssc.lookup_compound(input_string="སཀྲ་ཤིས་", language="fr", edit_distance_max=2))

print('Test 5')
# doesn't do much...
print(ssc.load_dictionary("lists/tib.1.txt", language="fr", term_index=0, count_index=1))
print(ssc.lookup_compound(input_string="དཀྲ'ཤེས'", language="fr", edit_distance_max=2))
