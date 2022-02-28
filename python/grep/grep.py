import re
def grep(pattern, flags, files):
    answer = ""
    for file in files:
        nb_lines = 0
        i_flag = re.IGNORECASE if re.search('i', flags) else 0 # If we get i, we have to ignore case and use it. If not, no flags.
        file_name = f"{file}:" if len(files) > 1 else "" # If we get more than 1 file, we have to identify where the line came from.
        with open(file) as f:
            if re.search('l', flags): # The l flag just asks us that we return the file names where the pattern can be found.
                if re.search(pattern, f.read()):
                    answer += f"{file}\n"
            else:
                if re.search('x', flags): # The x flag asks us that we do an exact match of the entire sentence.
                    match_func = lambda x: re.match(pattern, x, flags = i_flag)
                else:
                    match_func = lambda x: re.search(pattern, x, flags = i_flag) # Regular regex search.
                if re.search('v', flags): # The v flag inverts everything and asks we find everything that DOESN`T match.
                    new_match_func = lambda x: not match_func(x)
                else:
                    new_match_func = match_func
                for line in f.readlines(): # Now iterate over every line
                    nb_lines += 1
                    n_flag = f"{nb_lines}:" if re.search('n', flags) else "" # If the n flag is active, we get the number of lines. 
                    if new_match_func(line):
                        answer+= f"{file_name}{n_flag}{line}" # If the match works, it`s added to the answer variable with all the necessary flags.
    return answer
 