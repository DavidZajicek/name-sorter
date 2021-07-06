#-------------------------------------------------------------------------------
# Name:        name-sorter
# Purpose:
#
# Author:      David.Zajicek
#
# Created:     30/06/2021
# Copyright:   (c) David.Zajicek 2021
# Licence:     <your licence>
#-------------------------------------------------------------------------------

from operator import attrgetter

unsorted_names_string = ""
##Janet Parsons
##Vaughn Lewis
##Adonis Julius Archer
##Shelby Nathan Yoder
##Marin Alvarez
##London Lindsey
##Beau Tristan Bentley
##Leo Gardner
##Hunter Uriah Mathew Clarke
##Mikayla Lopez
##Frankie Conner Ritter


single_name_test = """Hunter Uriah Mathew Clarke"""
two_name_test = """
Mikayla Lopez
Hunter Uriah Mathew Clarke
Frankie Conner Ritter"""



##def split_person_names(names_list):
##    """ Split a list of names up in to individual people, and then using those
##        names, split them further using split_person_name() function. """
##    people = names_list.split("\n")
##    names = []
##    for person in people:
##        if person != '':
##            names.append(split_person_name(person))
##    return names

##def create_better_array(name_ls):
##    person = Person(split_person_name(name_ls)[0], split_person_name(name_ls)[1])
##    return person



class Person:
    def __init__(self, givenname, surname):
        self.givenname = givenname
        self.surname = surname
    def __repr__(self):
        return repr((self.givenname, self.surname))


def split_person_name(name):
    """ Split a full name up in to a name of arrays, with Given Names being
        nest inside a single array and last name being separate. """
    names = name.split()
    names_formated = Person(" ".join(names[:len(names)-1]), names[len(names)-1])
    return names_formated


def create_people_list(people):
    split_people = []
    for person in people:
        if person != '':
            split_people.append(split_person_name(person))
    return split_people



def main():
    unsorted_names_file = open("unsorted-names-list.txt", "r")
##    unsorted_string = ""
    unsorted_string = unsorted_names_file.read().splitlines()
    unsorted_names_file.close()
    #sorted_list = sorted(create_people_list(unsorted_string), key=lambda person: person.surname)
    sorted_list = sorted(create_people_list(unsorted_string), key=attrgetter('surname', 'givenname'))
    sorted_names_file = open("sorted-names-list.txt", "w")
    for person in sorted_list:
        print(person.givenname + " " + person.surname)
        sorted_names_file.write(person.givenname + " " + person.surname + "\n")
    sorted_names_file.close()



if __name__ == '__main__':
    main()